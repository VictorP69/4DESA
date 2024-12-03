L'api est disponible à l'URL : https://4desa-webapp-evehcbgthpencqgh.francecentral-01.azurewebsites.net/

I - Développer en local

Il faudra d'abord modifier le fichier appsettings.json

1) Pour la connection string : 
"DevConnection": "Server=tcp:4desa-sqlserver.database.windows.net,1433;Initial Catalog=sqldb;Persist Security Info=False;User ID=adminsql;Password=Adminroot4desa;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

2) Pour le blob storage: 
"ConnectionString": "DefaultEndpointsProtocol=https;AccountName=4desaproj;AccountKey=d8ePtiFl9fMnCzugguIw4FLY2SxYaZ+IcAa0//KkO92OuxZlyDKzzi2uaEmK6tm+rv9+6esj+SJG+ASt9WHpGA==;EndpointSuffix=core.windows.ne"

"ContainerName": "4desa-container"

II - Déploiement

Pour générer le dossier publish : dotnet publish -c Release -o .\publish\ .\social-media.csproj
Il faudra ensuite mettre en archive zip ce dossier.
Pour déployer : az webapp deploy --resource-group 4DESA-project --name 4desa-webapp --src-path .\publish.zip --type zip








