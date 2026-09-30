using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Learn C# Programming",
            "Programming Academy",
            600
        );

        video1.AddComment(new Comment(
            "John",
            "This video helped me understand C#."
        ));

        video1.AddComment(new Comment(
            "Maria",
            "Great explanation!"
        ));

        video1.AddComment(new Comment(
            "David",
            "I learned a lot from this video."
        ));

        video1.AddComment(new Comment(
            "Sarah",
            "Very useful tutorial."
        ));

        videos.Add(video1);

        // Video 2
        Video video2 = new Video(
            "Introduction to Programming",
            "Code School",
            480
        );

        video2.AddComment(new Comment(
            "Michael",
            "This is a great introduction."
        ));

        video2.AddComment(new Comment(
            "Ana",
            "Very easy to understand."
        ));

        video2.AddComment(new Comment(
            "Carlos",
            "I liked the examples."
        ));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video(
            "Object Oriented Programming",
            "Computer Science Channel",
            720
        );

        video3.AddComment(new Comment(
            "James",
            "Classes make much more sense now."
        ));

        video3.AddComment(new Comment(
            "Emily",
            "Good explanation of objects."
        ));

        video3.AddComment(new Comment(
            "Daniel",
            "I am going to practice this."
        ));

        video3.AddComment(new Comment(
            "Laura",
            "Thank you for the tutorial."
        ));

        videos.Add(video3);

        // Display each video and its comments.
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(
                    $"- {comment.GetName()}: {comment.GetText()}"
                );
            }

            Console.WriteLine();
        }
    }
}