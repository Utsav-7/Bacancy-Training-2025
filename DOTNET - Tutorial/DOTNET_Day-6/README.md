# DOTNET Day - 6 : Role Based Access Control

## Overview
This project implements **Role-Based Access Control (RBAC)** using **ASP.NET Core Web API** with **JWT Authentication**. It allows users to register, log in, and access role-protected resources based on their assigned role (**Admin, Employee, etc.**).
- ✅ **User Registration** (with hashed passwords)
- ✅ **JWT Token Generation** for authentication
- ✅ **Role-Based Authorization** (Admin & Employee)
- ✅ **Protected API Endpoints** with `[Authorize]` attribute

## Output: 
### User Registration based on role: 
![Screenshot 2025-02-25 142203](https://github.com/user-attachments/assets/5dbaf126-122f-4049-b57c-fab5ac97e93b)
### User Login and generate token based on role: 
![Screenshot 2025-02-25 142230](https://github.com/user-attachments/assets/57143368-db6f-4cdf-8907-dcfa7e6b499b)
### Employee Dashboard (Access through Employee token): 
![Screenshot 2025-02-25 142247](https://github.com/user-attachments/assets/dbc787e5-03ae-4ba1-829d-83e59660ecc5)
### Admin Dashboard (Access through Admin token);
![Screenshot 2025-02-25 142445](https://github.com/user-attachments/assets/156fa657-c374-4827-8049-ab62a4bf6f2d)
