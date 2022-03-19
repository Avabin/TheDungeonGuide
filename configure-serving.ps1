#!/usr/bin/env pwsh
function Write-LogInfo {
    param ($msg)
    Write-Host "$(Get-Date -Format "dd.MM.yyyy HH:mm:ss.fff") | INF | $msg" -ForegroundColor Green
}

function Write-LogError {
    param ($msg)
    Write-Host "$(Get-Date -Format "dd.MM.yyyy HH:mm:ss.fff") | ERR | $msg" -ForegroundColor Red
}

$kubeCtlCommand = Get-Command "kubectl" -ErrorAction SilentlyContinue
if(-Not $kubeCtlCommand) {
    Write-LogError "kubectl command not found"
    exit 1
}

Write-LogInfo "Found kubectl"

Write-LogInfo "Deploying Knative Serving CRDs"
kubectl apply -f https://github.com/knative/serving/releases/download/knative-v1.3.0/serving-crds.yaml

Write-LogInfo "Installing Knative core components"
kubectl apply -f https://github.com/knative/serving/releases/download/knative-v1.3.0/serving-core.yaml

Write-LogInfo "Installing netowrk layer (Kourier)"
kubectl apply -f https://github.com/knative/net-kourier/releases/download/knative-v1.3.0/kourier.yaml

Write-LogInfo "Patching Knative Serving to use Kourier"
kubectl patch configmap/config-network --namespace knative-serving --type merge --patch '{"data":{"ingress.class":"kourier.ingress.networking.knative.dev"}}'

Write-LogInfo "Configuring sslip.io local domain"
kubectl apply -f https://github.com/knative/serving/releases/download/knative-v1.3.0/serving-default-domain.yaml

Write-LogInfo "Everything should be configured and ready"
Write-LogInfo "Watching Knative pods status. Hit CTRL+C to exit"
kubectl get pods -n knative-serving --watch
