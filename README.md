# Titán

## Configuración

**C#**

Para Visual Studio 2013 se debe instalar [TypeScript](https://www.microsoft.com/en-us/download/details.aspx?id=48739)

Para clonar el proyecto desde la consola de git se debe escribir el siguiente comando:

```sh
$ git clone https://github.com/practicasprof12/gestionmateriales
```

**Base de datos**

- Ejecutar el [script](https://github.com/practicasprof12/gestionmateriales/blob/refactor/scripts/script_titan_otusers_schema.sql) para crear el schema de la base de datos de **usuarios, roles y permisos**.

- El schema de la base de datos de **materiales** se genera automaticamente cuando se ejecuta la aplicación

## Deploy

Directorio, se realiza dentro del directorio **/bin** ubicado dentro del proyecto

- En el menu **Compilar** seleccionar la opción **Publicar**
- Seleccionar el perfil **Local**
- Hacer click en botón **Publicar**

Local, se realiza hacia el **IIS** de forma local

- En el menu **Compilar** seleccionar la opción **Publicar**
- Seleccionar el perfil **Local IIS**
- Hacer click en botón **Publicar**

Remoto, se realiza directamente hacia el servidor que va a hostear la aplicación

- En el menu **Compilar** seleccionar la opción **Publicar**
- Seleccionar el perfil **win2012-01**
- Hacer click en botón **Publicar**
