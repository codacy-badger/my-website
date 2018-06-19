using System;
using mywebsite.Controllers;
using Xunit;

using my_website.Data;
using my_website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace XUnitTestProject
{
    public class BlogControllerTests : BlogTestBase
    {
        public List<Post> getListResult(IActionResult result)
        {
            var objectResult = Assert.IsType<OkObjectResult>(result);
            return objectResult.Value as List<Post>;
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var controller = new BlogController(_context);

            // Act
            var result = getListResult(controller.GetAll());

            // Assert
            Assert.Equal("yes", result[0].Text);
        }
    }
}