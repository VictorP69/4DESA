L'api est disponible à l'URL : https://4desa-webapp-evehcbgthpencqgh.francecentral-01.azurewebsites.net/

I - Développer en local

Vous pouvez lancer l'API en local et effectuer des modifications dessus, par défaut vous avez accès à la database sur azure et au blob storage, mais vous pouvez modifier les valeurs dans le .env pour ajouter votre propre db ou un blob storage de dev

II - Déploiement

Pour générer le dossier publish : dotnet publish -c Release -o .\publish\ .\social-media.csproj
Il faudra ensuite mettre en archive zip ce dossier.
Pour déployer : az webapp deploy --resource-group 4DESA-project --name 4desa-webapp --src-path .\publish.zip --type zip








