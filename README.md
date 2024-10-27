**Assumptions:**
1. In the 1st and the 3rd scenario the order is assumed to be placed before 7 pm, therefore discount on drinks is applied.
2. In the 2nd scenario the understanding is that the bill was first calculated when only 2 people placed the order and then the same bill was updated to reflect the order when 2 more people joined.
3. The code to make a POST request to calculate bill API is written but its commented. If there were an actual endpoint then code would run just by uncommenting the commented region containing the code logic.
4. Framework used is a lightweight version of the actual API framework, meaning it can be expanded to handle more complex API testing scenarios.
   For scope of the interview task, framework has appropriate capabilities.

**The solution is structured as below:** 
1. **Feature folder:** contains three scenarios as given in the task
2. **Step Definition folder:** contains the steps for the feature file
3. **ApiFramework folder:** contains classes that have methods to make API calls
4. **Constants folder:** Holds constants such as price of the item, discount etc.
5. **Context class folder:** Context class for the calculate Bill step definition file
6. **Hooks:** The hooks file is included but does not contain any logic relevant for this particular task
7. **Modal Classes folder:** contains modal classes for the calculate bill API request & response.
8. **Utility folder:** contains config manager class used to read configuration file
9. **config.json file:** contains configurations such as calculate Bill API url.

**Framework best practices are followed as below:** 
1. Reusable steps are written in feature file
2. Constants are maintained in a separate class for maintainability
3. API url is fetched from config file rather than hard coding 

**Framework Design principles:**
1. Oops principles are followed such as
1.1. Abstraction- Logic to calculate the bill is written in the context class rather than writing in the step definition class
1.2. Encapsulation- variables used in the calculation of the bill are defined as properties in the context class
1.3. Inheritance - no use case in current context
1.4. Polymorphism - no use case in current context
2. Dependency injection is used to inject 'CalculateBillcontext' and 'ApiClient' classes into step definition class
3. Separation of concern is followed in methods and classes

   
