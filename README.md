# Top Shelf - NHL Forum

Top Shelf - NHL Forum is an ASP.NET Core MVC forum application developed as part of a series of assignments focused on implementing CRUD functionality and user authentication using ASP.NET Core Identity. This project demonstrates hands-on experience with Dotnet C#, Entity Framework Core, Razor views, and custom styling.

## Features

### Assignment 1: CRUD for Discussions and Comments
- **Discussions:**
  - Create, read, update, and delete discussion threads.
  - Users can upload an image when creating a discussion.
  - The home page displays discussions in descending order by creation date.
  - Each discussion shows a thumbnail, title, comment count, and creation date.
- **Comments:**
  - Each discussion thread can have multiple comments.
  - Users can create, edit, and delete comments.
  - Comments display the content, posted date, and the name of the user who posted the comment.

### Assignment 2: Authentication & User Management
- **ASP.NET Core Identity Integration:**
  - Users can register, log in, and manage their profiles.
  - Custom fields have been added to the user model, including:
    - **Name** (Full Name, required)
    - **Location**
    - **ImageFilename** (stores the filename of the uploaded profile picture)
    - **ImageFile** (an `IFormFile` for uploads, not mapped to the database)
  - The navigation bar includes a login partial that displays Register, Login, Logout, and a "My Threads" link when the user is logged in.
  - When creating discussions and comments, the logged-in user's ID is saved, and proper access control ensures only the owner can edit or delete their posts.

### Additional Functionality
- **Profile Page:**
  - Displays the user's profile picture, full name, and location.
  - Lists the user's discussions and comments, with clickable links to each thread.
- **Styling & UI Enhancements:**
  - Custom CSS using Bootstrap and CSS variables for a modern look.
  - Rounded elements, smooth scroll animations, and inline SVG icons for actions.

## Getting Started

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or your preferred IDE
- SQL Server (LocalDB is used by default)

### Installation & Setup

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/TopShelfNHLForum.git
   cd TopShelfNHLForum
