# Docker for Developers

## Purpose

Setting up new developers is a pain, and making sure everyone's development environment is running under the same assumptions is a full time job. On top of that, once set up the developer can be free of dependencies such as network connectivity and shared data stores. Another big benefit is that any version upgrades that need to be tested can easily be reverted instead of trying to make sure all of your local system's settings are back to normal.

## Implementation

The implementation is fairly easy to get set up, and due to the plethora of images available the approach should be transferrable to your language/platform of choice.

Starting with the `docker-compose.yml` file, the setup desribes the environments for three containers:

- Database _(microsoft/mssql-server-linux)_
- .NET Core Middle Tier _(microsoft/dotnet:sdk)_
- Angular Front End Application _(teracy/angular-cli)_

Swapping these components out for a container that suits your needs should be fairly trivial. The only thing that stymied me when making the switch was that all my ports were aligned correctly. After the setup worked once though, all that needs to be done is open up a command line and type `docker-compose up` and things are up and running.

Another big advantage is that this setup is completely platform independant. Team members can work on any operating system they prefer and still have the same setup as everyone else as long as Docker is installed.