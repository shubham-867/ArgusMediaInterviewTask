**The solution is structured as below:** 
**Feature folder:** contains three scenarios as given in the task
**Step Definition folder:** contians the steps for the feature file
**ApiFramework folder:** containes classes that have methods to make API calls
**Constants folder:** Holds contants such as price of the item, discount etc.
**Context class folder:** Context class for the calculate Bill step definition file
**Hooks:** The hooks file is included but does not contain any logic relevent for this particular task
**Modal Classes folder:** contians modal classes for the calculate bill API request & response.
**Utility folder:** contains config manager class used to read configuration file
**config.json file:** contians configurations such as calculate Bill API url.

**Assumptions:**
1. In the 1st and the 3rd scenario the order is assumed to be placed before 7 pm, therefore discount on drinks is applied.
2. In the 2nd scenario the understanding is that the bill was first calculated when only 2 people placed the order and then the same bill was updated to reflect the order when 2 more people joined.
3. The code to make a POST request to calculate bill API is written but its commented. If there were an actual endpoint then code would run just by uncommenting the commented region containig the code logic.
4. Framework used is a lightweight version of the actual API framework, meaning it can be expanded to handle more complex API testing scenarios.
   For scope of the interview task, framework has appropriate capebilites.

**Framework best practices are followed as below:** 
1. Resuable steps are witten in feature file
2. Constants are maintained in a separate class for maintability
3. API url is fetched from config file rather than hard coding
4. 

**Framework Design principles: **
2. Oops principles are followed such as
    2.1. Abstraction- Logic to calculate the bill is written in the context class rather than writting in the step definition class
    2.2. Encapsulation- variables used in the calculation of the bill are defined as propertise in the context class
    2.3. Inheritance - no use case in current context
    2.4. Polymorphism - no use case in current context
4. Dependency injection is used to inject 'CalculateBillcontext' and 'ApiClient' classes into step definition class
7. Separation of concern is followed in methods and classes

   
