#Requires

param(
    [ValidateSet("Characters.Api", "Characters.Mongo","DeadLetterSink", "All")]
    [string[]]$Services = @("All")
)

if($Services -contains "All") {
    $Services = @("Characters.Api", "Characters.Mongo", "DeadLetterSink")
}
$builds = $Services | % {@{File='tdg.build.ps1'; Services=@("$_")}}

Build-Parallel $builds