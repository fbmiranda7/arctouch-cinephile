# ArcTouch Cinephile Mobile Code Challenge

This repo contains the source code for the ArcTouch Mobile Code Challenge

## Main objective
Fetch from the TMDb REST API upcoming movies and genres then display the results in a user friendly application

## Development
Only the android layer was developed, using Xamarin.Forms with the following versions:
* Microsoft Visual Studio 2017 
* Xamarin 4.6.0.299

## Third-Party
The following nuget libraries were added to the project seeking code scalability and a better user experience:

#### FFImageLoading
Caches the images on ListViews preventing image flickering during the scroll

#### Portable.Ninject
Creates a dependency injection container, increasing code flexibility for customization and scalability.

#### Microsoft.Net.Http
Delivers a Http client for direct and simple REST calls

#### Newtonsoft.Json
Deserializes strings containing Json formatted objects

## Compiling
A direct build targeting a developer enabled Android device should do the trick, it's expected that the nuget packages to be restored automatically during the build.
