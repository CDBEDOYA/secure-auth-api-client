# secure-auth-api-client

Proyecto completo de autenticación segura compuesto por:

- **API backend en .NET 8** con autenticación JWT
- **Aplicación móvil en React Native** que consume la API y almacena los tokens de forma segura

Este proyecto está diseñado para demostrar buenas prácticas de seguridad, arquitectura limpia, integración entre frontend y backend, y uso de tecnologías modernas para la autenticación segura de usuarios.

---

## 📁 Estructura del proyecto

```
secure-auth-api-client/
├── api/        # API REST en .NET 8
└── client/     # App móvil en React Native
```

---

## 🔐 API - .NET 8 (`/api`)

### Funcionalidad:
- Registro de usuario
- Inicio de sesión (login) con generación de JWT
- Endpoint protegido (`/profile`)
- Validación de token
- Middleware de autenticación

### Tecnologías:
- ASP.NET Core 8
- JWT (JSON Web Tokens)
- Swagger para documentación
- C# minimal API + controllers

### Ejecución local:
```bash
cd api
dotnet run
```

La API estará disponible por defecto en `http://localhost:5000`

---

## 📱 Cliente - React Native (`/client`)

### Funcionalidad:
- Pantallas de login y perfil
- Almacenamiento seguro del token con SecureStore
- Navegación condicional basada en autenticación
- Lógica de consumo de API protegida con token JWT

### Tecnologías:
- React Native (Expo)
- Expo SecureStore
- Fetch API para consumo de servicios

### Ejecución local:
```bash
cd client
npx expo start
```

---

## 🚀 ¿Cómo empezar?

1. Clona este repositorio.
2. Corre el backend con `dotnet run` desde `/api`
3. Corre la app móvil con `expo start` desde `/client`
4. Registra un usuario en la API, luego inicia sesión.
5. El token será almacenado en el dispositivo y usado para acceder al perfil protegido.

---

## 🧪 Futuras mejoras

- Hash de contraseñas
- Base de datos persistente (SQLite o PostgreSQL)
- Manejo de errores más robusto
- Navegación completa (registro, logout, etc.)
- Validación de formularios
- UI más estilizada

---

## 🧑‍💻 Autor

David Urrego  
Ingeniero Electrónico - Desarrollador .NET y Móvil  
[LinkedIn](https://linkedin.com/in/davidurrego)  
