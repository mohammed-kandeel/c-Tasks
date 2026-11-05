using G_NET_84_EF02.Contexts;
namespace G_NET_84_EF02;

internal class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();

        if (context.Database.EnsureCreated())
            Console.WriteLine("Database created successfully.");
        else
            Console.WriteLine("Database already exists.");
    }
}


/*
 Database Name: EventHubDB

------------------------------------------------

1. Classes, Enums & Properties

1. Organizer
    - OrganizerId 
    - OrganizerName (Required)
    - CompanyName (Optional)
    - IsVerified (Required)

2. OrganizerProfile
    - OrganizerId 
    - Biography (Optional)
    - Website (Optional)
    - Logo (Optional)

3. Event
    - EventId 
    - Title (Required)
    - Description (Required)
    - StartDate (Required)
    - EndDate (Optional / Nullable)
    - MaxAttendees (Required)
    

4. Attendee
    - AttendeeId 
    - FullName (Required)
    - Email (Required)


  Adress (Complex Type) class  one to one relationship with Attendee class
    - Street (Required)
    - City (Required)
    - Country (Required)
    - PostalCode (Required)

5. Badge
    - BadgeId 
    - BadgeNumber (Required, Unique)
    - IssueDate (Required)
    - Tier (BadgeTier)  enum (Required)

------------------------------------------------

2. Enums  

BadgeTier
    - Standard
    - VIP


3. Relationships

Relationship	              |  Cardinality	|   Participation
------------------------------|-----------------|------------------------------------------------------
Organizer – OrganizerProfile  |  One-to-One	    |   Organizer (Optional), OrganizerProfile (Mandatory)
                              |                 |
Organizer – Event	          |  One-to-Many    |   Organizer (Optional), Event (Mandatory)
                              |                 |
Attendee – Badge	          |  One-to-One	    |   Attendee (Optional), Badge (Mandatory)

------------------------------------------------
4. Relationship Explanation

1. Organizer and OrganizerProfile: (Optional) One-to-One (Mandatory).
    - An organizer may have zero or one profile.
    - A profile must belong to exactly one organizer.

2. Organizer and Event: (Optional) One-to-Many (Mandatory).
    - An organizer may publish zero or many events.
    - Each event must belong to exactly one organizer.

3. Attendee and Badge: (Optional) One-to-One (Mandatory).
    - An attendee may have zero or one badge.
    - Each badge must belong to exactly one attendee.
 
 */
