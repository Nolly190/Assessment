**Library System API Documentation**
Welcome to the Library System API documentation! This API provides a comprehensive interface for managing the rental and reservation of books in our library. Whether you're a developer looking to integrate with our system or an administrator wanting to understand our functionalities, this documentation will guide you through the various features and endpoints available.
Overview
The Library System API is designed to facilitate seamless interactions with our library resources. It comprises three main controllers:
User Controller: Manage user accounts, including registration, authentication, and user profiles. This controller ensures a secure and personalized experience for all library members and admin.
Books Controller: Access and manage the library's collection of books. This includes retrieving book details, searching for titles, and updating book information.
Reservation Controller: Handle the reservation process for books, allowing users to secure a title for future borrowing. This controller ensures that users can reserve books efficiently and stay informed about their availability.
By utilizing these controllers, you can create, read, update, and delete resources as needed, making it easy to integrate our library services into your applications. Dive into the sections below to explore detailed information about each controller, including endpoints, request/response formats, and usage examples.
Happy coding!
Table of contents:
**🪐 Get Started
⏱ Rate and usage limits
✍️ Example Responses 
🪐 Get Started**
Steps to get started with the Library System API:
Authorization: StartFragmentTo access the Library System API endpoints, you will need a JWT bearer token obtained from the login endpoint. The system utilizes policy-based authorization, allowing administrators to create new roles and assign specific functionalities to them. This flexible approach ensures that users have access only to the resources and actions permitted by their assigned roles, enhancing both security and usability within the library system.EndFragment
Access: Access to any resource depends on your role, You have to elevate the permission on your role to access any new resource. For Test Purposes the Admin account details is as follows.
**UserName: Admin@gmail.com**
 **Password: AdminTest123**

For more details, check out the additional sections below, and click View Complete Documentation for the complete documentation. If you have questions about the folder or request, look for the documentation icon for documentation-in-context.
Rate and usage limits
API access rate limits apply at a per-API key basis in unit time. The limit is 300 requests per minute.
If you exceed either limit, your request will return an HTTP 429 Too Many Requests status code. If your team is consistently hitting these limits, contact the Admin of the system, and we will work to accommodate you.
