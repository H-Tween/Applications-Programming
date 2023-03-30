using ConsoleAppProject.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The Post class stores news posts for the news feed in a social network 
    /// application.
    /// 
    /// Display of the posts is currently simulated by printing the details to the
    /// terminal. (Later, this should display in a browser.)
    /// 
    /// This version does not save the data to disk, and it does not provide any
    /// search or ordering functions.
    ///</summary>
    ///<author>
    ///  Michael Kölling and David J. Barnes
    ///  version 0.1
    ///</author> 
    public class Post
    {
        public readonly List<MessagePost> messages;
        public readonly List<PhotoPost> photos;

        public int PostId { get; }
        public string PostType { get; set; }
        public static int instances = 0;
        private bool postExists { get; set; }

        // Fields
        public int likes;
        public List<String> comments;

        // Properties
        public DateTime Timestamp { get; set; }
        public String Username { get; set; }

        public int numberOfPosts = 0;

        ///<summary>
        /// Construct an empty news feed.
        ///</summary>
        public Post()
        {
            instances++;
            PostId = instances - 1;

            Timestamp = DateTime.Now;

            likes = 0;
            messages = new List<MessagePost>();
            photos = new List<PhotoPost>();
            comments = new List<String>();

        }

        ///<summary>
        /// Add a comment to this post.
        /// </summary>    
        public void AddComment()
        {
            Post post = GetPostFromId();
            if (post != null)
            {
                Console.WriteLine();
                Console.Write(" Please enter your text > ");
                string text = Console.ReadLine();
                post.comments.Add(text);
                ConsoleHelper.OutputTitle($"Created a comment");

            }
            else
            {
                InvaldID();
            }
        }

        /// <summary>
        /// Record one more 'Like' indication from a user.
        /// </summary>
        public void Like()
        {
            Post post = GetPostFromId();
            if (post != null) 
            {
                post.likes++;
                ConsoleHelper.OutputTitle($"Added a like");
            }
            else
            {
                InvaldID();
            }

        }

        ///<summary>
        /// Record that a user has withdrawn his/her 'Like' vote.
        ///</summary>
        public void Unlike()
        {
            Post post = GetPostFromId();
            if (post != null)
            {
                if (post.likes > 0)
                {
                    post.likes--;
                    ConsoleHelper.OutputTitle($"Removed a like");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" Cannot unlike a post with 0 likes... ");
                    Console.WriteLine();
                }
            }
            else
            {
                InvaldID();
            }
        }

        public string InputName()
        {
            Console.Write(" Enter your name > ");
            string name = Console.ReadLine();
            return name;
        }

        public Post GetPostFromId()
        {
            Display();
            int id = GetPostId();

            if (id == 0) { return null; }
            Post post = FindPost(id);
            return post;
        }

        public int GetPostId()
        {
            Console.Write(" Please enter the post by ID > ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (Post photoPost in photos)
            {
                if (photoPost.PostId == id)
                {
                    return id;
                }
            }
            foreach (Post messagePost in messages)
            {
                if (messagePost.PostId == id)
                {
                    return id;
                }
            }
            return 0;
        }



        ///<summary>
        /// Add a text post to the news feed.
        /// 
        /// @param text  The text post to be added.
        ///</summary>
        public void PostMessage()
        {
            string author = InputName();

            Console.Write(" Please enter your text > ");
            string text = Console.ReadLine();

            MessagePost post = new MessagePost(author, text);
            messages.Add(post);

            ConsoleHelper.OutputTitle(" You have just posted this image post: ");
            post.Display();
        }

        ///<summary>
        /// Add a photo post to the news feed.
        /// 
        /// @param photo  The photo post to be added.
        ///</summary>
        public void PostImage()
        {
            string author = InputName();

            Console.Write(" Please enter your image filename > ");
            string filename = Console.ReadLine();

            Console.Write(" Please enter your image caption > ");
            string caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(author, filename, caption);
            photos.Add(post);

            ConsoleHelper.OutputTitle(" You have just posted this image post: ");
            post.Display();

        }


        public Post FindPost(int id)
        {
            foreach(Post photoPost in photos)
            {
                if(photoPost.PostId == id)
                {
                    photoPost.PostType = "Photo";
                    return photoPost;
                }
            }
            foreach(Post messagePost in messages)
            {
                if(messagePost.PostId == id) 
                {
                    messagePost.PostType = "Message";
                    return messagePost;
                }
            }
            return null;
        }

        public int GetNumberOfPosts()
        {
            foreach (Post photoPost in photos)
            {
                numberOfPosts++;
            }
            foreach (Post messagePost in messages)
            {
                numberOfPosts++;
            }
            return numberOfPosts;
        }

        public void RemovePost()
        {
            Display();
            postExists = PostsExist();
            if (postExists)
            {
                int id = GetPostId();
                Post post = FindPost(id);
                if (post == null)
                {
                    Console.WriteLine($" \n This post does not exist!\n");
                }
                else
                {
                    Console.WriteLine($" \n The following Post {id} has been removed! \n");
                    if (post.PostType == "Photo")
                    {
                        photos.Remove((PhotoPost)post);
                    }
                    else if (post.PostType == "Message")
                    {
                        messages.Remove((MessagePost)post);
                    }
                    ConsoleHelper.OutputTitle($"Removing a post");
                }
            }
            else
            {
                NoPostsExist();
            }

        }

        public void NoPostsExist()
        {
            Console.WriteLine();
            Console.WriteLine(" No Posts available...");
            Console.WriteLine();
        }

        public void InvaldID()
        {
            Console.WriteLine();
            Console.WriteLine(" Invalid ID");
            Console.WriteLine();
        }

        public bool PostsExist()
        {
            if (messages.Count == 0 && photos.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Author()
        {
            Display();
            Console.Write(" Enter authors name > ");
            string userAuthor = Console.ReadLine();
            int posts = 0;
            foreach (Post photoPost in photos)
            {
                if (photoPost.Username == userAuthor)
                {
                    posts++;
                    photoPost.Display();
                    Console.WriteLine();
                }
            }
            foreach (Post messagePhost in messages)
            {
                if (messagePhost.Username == userAuthor)
                {
                    posts++;
                    messagePhost.Display();
                }
            }
            if (posts == 0) 
            {
                Console.WriteLine();
                Console.WriteLine(" No posts with that author...");
                Console.WriteLine();
            }

        }



        ///<summary>
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal. (To do: replace this later with display in web browser.)
        ///</summary>
        public virtual void Display()
        {
            postExists = PostsExist();
            if (postExists)
            {   
                // display all text posts
                foreach (MessagePost message in messages)
                {
                    message.Display();
                    Console.WriteLine();   // empty line between posts
                }

                // display all photos
                foreach (PhotoPost photo in photos)
                {
                    photo.Display();
                    Console.WriteLine();   // empty line between posts
                }
            }
            else
            {
                NoPostsExist();
            }
        }

        public void DisplayMenu()
        {
            bool quit = false;

            string[] choices = new string[] { "Add Message", "Add Photo", "Remove post", "Display All", "Add a comment", "Like a post", "Unlike a post", "Display by author", "Quit" };

            // testing
            string author = "Author name";
            string filename = "ThisFilename";
            string caption = "Caption";
            photos.Add(new PhotoPost(author, filename, caption));

            Console.WriteLine();

            do
            {
                int choice = ConsoleHelper.SelectChoice(choices);

                switch (choice)
                {
                    case 1: PostMessage(); Console.WriteLine(); break;
                    case 2: PostImage(); Console.WriteLine(); break;
                    case 3: RemovePost(); break;
                    case 4: Display(); break;
                    case 5: AddComment(); break;
                    case 6: Like(); break;
                    case 7: Unlike(); break;
                    case 8: Author(); break;
                    case 9: quit = true; Console.WriteLine();  break;
                }
            } while (!quit);



        }
        /// <summary>
        /// Create a string describing a time point in the past in terms 
        /// relative to current time, such as "30 seconds ago" or "7 minutes ago".
        /// Currently, only seconds and minutes are used for the string.
        /// </summary>
        /// <param name="time">
        /// The time value to convert (in system milliseconds)
        /// </param> 
        /// <returns>
        /// A relative time string for the given time
        /// </returns> 
        public String FormatElapsedTime(DateTime time)
        {
            DateTime current = DateTime.Now;
            TimeSpan timePast = current - time;

            long seconds = (long)timePast.TotalSeconds;
            long minutes = seconds / 60;

            if (minutes > 0)
            {
                return minutes + " minutes ago";
            }
            else
            {
                return seconds + " seconds ago";
            }
        }
    }

}
