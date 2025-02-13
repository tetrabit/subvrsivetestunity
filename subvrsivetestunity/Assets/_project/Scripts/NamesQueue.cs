using System.Collections.Generic;

public static class NamesQueue
{
    // A public, readonly Queue of 100 names.
    public static readonly Queue<string> Names = new Queue<string>(new List<string>
    {
        "Alice", "Bob", "Charlie", "David", "Emma", "Frank", "Grace", "Henry", "Isabella", "Jack",
        "Karen", "Liam", "Mia", "Noah", "Olivia", "Peter", "Quinn", "Ryan", "Sophia", "Thomas",
        "Uma", "Victor", "Wendy", "Xander", "Yara", "Zachary", "Aaron", "Bella", "Carter", "Daisy",
        "Ethan", "Fiona", "Gavin", "Hannah", "Ian", "Jasmine", "Kyle", "Lucy", "Miles", "Nina",
        "Owen", "Paige", "Quentin", "Ruby", "Samuel", "Tara", "Ulysses", "Violet", "Walter", "Xenia",
        "Yvonne", "Zane", "Abby", "Brandon", "Caitlyn", "Derek", "Elena", "Felix", "Gabrielle", "Harvey",
        "Irene", "Julian", "Kelsey", "Leon", "Madeline", "Nathan", "Ophelia", "Preston", "Quincy", "Riley",
        "Sienna", "Tristan", "Ursula", "Vince", "Whitney", "Ximena", "Yosef", "Zara", "Aiden", "Brianna",
        "Caleb", "Delilah", "Elias", "Faith", "George", "Hazel", "Isaac", "Jade", "Kevin", "Lola",
        "Marcus", "Nora", "Oscar", "Penelope", "Quinton", "Rose", "Steven", "Tiffany", "Umar", "Vanessa"
    });
}