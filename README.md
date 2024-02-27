## Presentación

Proyecto de ejemplo para el uso de worker services en .NET 8 mediante un proyecto WebApi.

## Uso

En Program.cs disponemos de la clase Daemon injectada como Hosted Service el cúal se ejecutara ciclicamente en base a la configuración de las funciones StartAsync y StopAsync implementadas de la interfaz IHostedService.

Sera necesario rellenar la función TimerTick con aquellas ejecuciones que deseemos programar.

Actualmente en esta última función TimerTick se encuentra configurado para que el Timer se ejecute cada 5 segundo con la finalidad de poder observar mejor el funcionamiento. Sera necesario ajustarlo a las necesidades