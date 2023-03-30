using ConsoleAppProject.App04;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// This class stores information about a post in a social network. 
    /// The main part of the post consists of a (possibly multi-line)
    /// text message. Other data, such as author and time, are also stored.
    /// </summary>
    /// <author>
    /// Michael Kölling and David J. Barnes
    /// version 0.1
    /// </author>
    public class MessagePost : Post
    {
        
        public String Message { get; }

        /// <summary>
        /// Constructor for objects of class MessagePost.
        /// </summary>
        /// <param name="author">
        /// The username of the author of this post.
        /// </param>
        /// <param name="text">
        /// The text of this post.
        /// </param>
        public MessagePost(String author, String text)
        {
            Username = author;
            Message = text;
        }


        ///<summary>
        /// Display the details of this post.
        /// 
        /// (Currently: Print to the text terminal. This is simulating display 
        /// in a web browser for now.)
        ///</summary>
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine($"    Message: {Message}");
            Console.WriteLine();
            Console.WriteLine($"    PostID:         {PostId}");
            Console.WriteLine($"    Author:         {Username}");
            Console.WriteLine($"    Time Elpased:   {FormatElapsedTime(Timestamp)}");
            Console.WriteLine();

            if (likes > 0)
            {
                Console.WriteLine($"    Likes:  {likes}  people like this.");
            }
            else
            {
                Console.WriteLine();
            }

            if (comments.Count == 0)
            {
                Console.WriteLine("    No comments.");
            }
            else
            {
                Console.WriteLine("    Comments:   ");
                foreach (string comment in comments)
                {
                    Console.WriteLine($"    {comment}  ");
                }
            }
        }   
    }
}
