using System;
using System.Security;

namespace ConsoleObject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                GrcEntite myObject = new GrcEntite();

                // Get the type of 'GrcEntite'.
                Type myType = myObject.GetType();

                // Get the information related to all public member's of 'GrcEntite'.
                var myMemberInfo = myType.GetMembers();

                Console.WriteLine("\nThe members of class '{0}' are :\n", myType);
                foreach (var t in myMemberInfo)
                {
                    // Display name and type of the concerned member.
                    Console.WriteLine("'{0}' is a {1}", t.Name, t.MemberType);
                }
            }
            catch (SecurityException e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }
        }
    }
}