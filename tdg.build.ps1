param(
    [ValidateSet("Characters.Api", "Characters.Mongo", "DeadLetterSink", "All")]
    [string[]]$Services = @("All"),
    $imageTag = "latest"
)
$solutionPath = $PSScriptRoot

$servicesData = @(@{
    Name = "Characters.Api";
    Dockerfile = "./Functions/Characters/Characters.Api/Dockerfile";
    ImageName = "ghcr.io/avabin/characters-api";
    FunctionName = "characters-api";
},@{
    Name = "Characters.Mongo";
    Dockerfile = "./Functions/Characters/Characters.Mongo/Dockerfile";
    ImageName = "ghcr.io/avabin/characters-mongo";
    FunctionName = "characters-mongo";
},@{
    Name = "DeadLetterSink";
    Dockerfile = "./Functions/DeadLetterSink/Dockerfile";
    ImageName = "ghcr.io/avabin/deadlettersink";
    FunctionName = "deadletters-sink";
}
#,@{
#    Name = "Sessions.Api";
#    Dockerfile = "./Functions/Sessions/Sessions.Api/Dockerfile";
#    ImageName = "ghcr.io/avabin/sessions-api";
#    FunctionName = "sessions-api";
#}, @{
#    Name = "Sessions.Mongo";
#    Dockerfile = "./Functions/Sessions/Sessions.Mongo/Dockerfile";
#    ImageName = "ghcr.io/avabin/sessions-mongo";
#    FunctionName = "sessions-mongo";
#}
)

$servicesToDeploy = $servicesData | where {$_.Name -in $Services}
if ($Services.Contains("All")) {
    $servicesToDeploy = $servicesData
}

task DeployInf {
    Write-Host "Updating k8s resources"

    exec {kubectl -f ./Charts/tdg.yml apply}
}

task BuildDockerImages {
    Write-Host "Building docker images"
    
    foreach ($service in $servicesToDeploy) {
        Write-Host "Building docker image for $($service.Name)"
        exec {docker build -t "$($service.ImageName):$imageTag" -f $($service.Dockerfile) $solutionPath} 
    }
}

task PushDockerImages {
    Write-Host "Pushing docker images"
    
    foreach ($service in $servicesToDeploy) {
        Write-Host "Pushing docker image for $($service.Name)"
        exec {docker push "$($service.ImageName):$imageTag"}
    }
} 

task DeployDockerImages {
    Write-Host "Deploying docker images"
    
    foreach ($service in $servicesToDeploy) {
        Write-Host "Deploying docker image for $($service.Name)"
        $functionName = $service.FunctionName
        exec {kn -n tdg service update $functionName --image="$($service.ImageName):$imageTag"}
    }
}

task . BuildDockerImages, PushDockerImages, DeployDockerImages