### Microsoft SSO with DotNet Backend and Angular Frontend

## Overview

This project demonstrates the integration of Microsoft login and normal login flows using an Angular frontend and a .NET backend. The purpose is to provide a seamless authentication experience while leveraging the security features provided by Microsoft Azure.

## Flowcharts

### Normal Login Flow
```plaintext
1. User enters credentials
   |
2. Angular frontend calls login API with username and password
   |
3. .NET backend
   |
4. Validate credentials
   |
5. Generate JWT
   |
6. Send JWT to Angular frontend
   |
7. Store JWT
   |
8. Log in user
```

### Microsoft Login Flow
```plaintext
1. User clicks 'Login with Microsoft'
   |
2. Angular frontend
   |
3. Redirect to Microsoft OAuth
   |
4. Microsoft OAuth server
   |
5. Authenticate user
   |
6. Redirect back with ID token
   |
7. Angular frontend
   |
8. Angular frontend calls login API with token
   |
9. Validate ID token
   |
10. Retrieve user info
   |
11. Generate JWT
   |
12. Send JWT to Angular frontend
   |
13. Store JWT
   |
14. Log in user
```

## Setup Instructions

### Backend (.NET)

Navigate to the API directory and start the .NET backend:

```bash
cd api
dotnet watch run
```

### Frontend (Angular)

1. Update `clientId` in `angular-frontend/src/app/app.module.ts`.

2. Navigate to the Angular frontend directory, install dependencies, and start the application:

```bash
cd angular-frontend
npm install
npm run start
```

## Usage

- Open the frontend at `http://localhost:4200`.
- Click on the "Login with Microsoft" button.
- After successful login, the response from the backend will be shown.

This setup ensures that both normal login and Microsoft SSO flows are properly implemented and tested, providing a robust authentication system for your application.