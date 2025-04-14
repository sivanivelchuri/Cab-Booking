# 🚖 Urban Rider – Cab Booking Project

Urban Rider is a cab booking web application built using **ASP.NET MVC** with a **SQL Server database**, following the **Entity Framework** for ORM. This project provides seamless interfaces for both **Admin (including Riders)** and **Users (Customers)**.

---

## 🛠️ Technologies Used
- ASP.NET MVC
- Entity Framework
- SQL Server
- JWT Authentication

---

## 👤 Interfaces

### 🔐 Admin Panel (Riders & Admins)
- Role-based access using **JWT tokens**.
- **Admin** can:
  - Add new riders.
  - Manage rider details and monitor bookings.
- **Rider** can:
  - View the bookings assigned to them.
  - Accept or cancel rides once a customer has booked.

### 🚗 User Panel (Customers)
- Users can:
  - Book rides based on destination and preferred car model.
  - View their **current** and **past bookings**.
  - Track whether the ride is accepted or canceled by a rider.

---

## 🧩 SQL Database Tables

👤 User Table

🛡️ Admin Table

📃 BookingList Table

🚘 Car Model Table

👩‍💻 Author
Sivani – Associate Software Engineer passionate about full-stack development and building real-world applications.
