using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HelloMVC.Models;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            // Constructor logic (if needed)
        }

        // Display all discussions
        public IActionResult Index()
        {
            // Create a list of discussions
            List<Discussion> discussions = new List<Discussion>();

            // Create 3 discussion objects 
            Discussion discussion1 = new Discussion()
            {
                DiscussionId = 1,
                Title = "Sidney Crosby Injured before four nations tournament",
                Content = "He was injured and now he can't play",
                ImageFilename = "crosby.jpg",
                IsPublic = true // Ensure this property exists in your Discussion model
            };

            Discussion discussion2 = new Discussion()
            {
                DiscussionId = 2,
                Title = "Sidney Crosby Injured before four nations tournament",
                Content = "He was injured and now he can't play",
                ImageFilename = "crosby.jpg",
                IsPublic = true
            };

            Discussion discussion3 = new Discussion()
            {
                DiscussionId = 3, // Corrected ID
                Title = "Malkin playing",
                Content = "He was injured and now he can't play",
                ImageFilename = "malkin.jpg",
                IsPublic = true
            };

            // Add to the list
            discussions.Add(discussion1);
            discussions.Add(discussion2);
            discussions.Add(discussion3);

            // Pass the list to the view
            return View(discussions);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}