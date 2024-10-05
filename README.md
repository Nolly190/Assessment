**Library System API Documentation**

Welcome to the Library System API! This API provides a robust interface for managing book rentals and reservations in our library. Whether you're a developer looking to integrate our system or an administrator needing to understand its functionalities, this documentation is your guide to the available features and endpoints.

**Overview**

The Library System API consists of three main controllers:

**User Controller:** Manage user accounts, including registration, authentication, and profiles, ensuring a secure experience for all library members and admins.

**Books Controller:** Access and manage the library’s book collection—retrieve details, search titles, and update information.

**Reservation Controller:** Facilitate the reservation process, allowing users to secure books for future borrowing and stay informed about availability.

With these controllers, you can perform CRUD operations to integrate our library services into your applications.

**Getting Started**

**Authorization**
To access the API endpoints, you need a JWT bearer token obtained from the login endpoint. Our system uses policy-based authorization, allowing admins to create roles and assign functionalities accordingly.

Test Admin Account:

**Username: Admin@gmail.com**

**Password: AdminTest123**


**Rate and Usage Limits**
API access is limited to 300 requests per minute per API key. Exceeding this limit will result in an HTTP 429 Too Many Requests status code. If you consistently hit these limits, please contact the system admin for assistance.

For detailed information about each controller, including endpoints and usage examples, please explore the postman documentation in the setup folder of the application
