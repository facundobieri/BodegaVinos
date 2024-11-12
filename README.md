# BodegaVinos API

Esta API permite gestionar una bodega de vinos, incluyendo un sistema de catas
Para el ejemplo de uso, se usara el User "Facundo" con contraseña "Facundo1234"

## ENDPOINTS
### Authenticate
Con solo un POST es necesario para autenticarse dentro del sistema ya que utiliza el token JWT dado en la response 
### Cata
Tiene un POST para crear una Cata  
UN GET para obtener todas las catas que tienen una fecha valida, lo cual significa que todavia no paso la fecha de la cata
y un PUT por Id que permite actualizar los invitados de la cata
### User
Con un POST para hacer un registro de usuario
### Wine
Un GET para obtener todos los vinos, otro GET por Variety para obtenerlos segun su variedad de vino
Un POST para Crear un nuevo vino
Dos PUT por Id para añadir stock o remover stock
