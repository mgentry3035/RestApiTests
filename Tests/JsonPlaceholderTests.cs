using NUnit.Framework;
using RestSharp;
using FluentAssertions;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace RestApiTests.Tests
{
    [TestFixture]
    public class JsonPlaceholderTests
    {
        private RestClient client;

        [SetUp]
        public void Setup()
        {
            // Load configuration from appsettings.json
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string baseUrl = config["BaseUrl"];
            client = new RestClient(baseUrl);
        }

        [TearDown]
        public void Cleanup()
        {
            client?.Dispose();
        }

        // ---------- GET ----------
        [Test]
        public void Get_Posts_ShouldReturn200()
        {
            var request = new RestRequest("/posts", Method.Get);
            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().Contain("userId");
        }

        // ---------- POST ----------
        [Test]
        public void Post_CreateNewPost_ShouldReturn201()
        {
            var request = new RestRequest("/posts", Method.Post);
            request.AddJsonBody(new
            {
                title = "QA Test Title",
                body = "This is a test post created via RestSharp",
                userId = 1
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Content.Should().Contain("QA Test Title");
        }

        // ---------- PUT ----------
        [Test]
        public void Put_UpdateExistingPost_ShouldReturn200()
        {
            var request = new RestRequest("/posts/1", Method.Put);
            request.AddJsonBody(new
            {
                id = 1,
                title = "Updated Post Title",
                body = "This post has been updated",
                userId = 1
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().Contain("Updated Post Title");
        }

        // ---------- DELETE ----------
        [Test]
        public void Delete_Post_ShouldReturn200()
        {
            var request = new RestRequest("/posts/1", Method.Delete);
            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        // ---------- NEGATIVE TEST ----------
        [Test]
        public void Get_InvalidEndpoint_ShouldReturn404()
        {
            var request = new RestRequest("/invalidEndpoint", Method.Get);
            var response = client.Execute(request);

            // Log output to the console
            Console.WriteLine("🧪 Negative Test: Invalid endpoint request executed.");
            Console.WriteLine($"➡️ Requested URL: {client.Options.BaseUrl}/invalidendpoint");
            Console.WriteLine($"⬅️ Response Status Code: {(int)response.StatusCode} {response.StatusCode}");
            Console.WriteLine($"📦 Response Content: {response.Content}");

            // Assert
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("✅ Expected 404 Not Found received — negative test passed.");
            }
            else
            {
                Console.WriteLine($"❌ Unexpected status code: {(int)response.StatusCode}");
            }

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}






