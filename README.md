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
6. **Hooks folder:** The hooks file.
7. **Modal Classes folder:** contains modal classes for the calculate bill API request & response.
8. **Utility folder:** contains utility classes such as config manager class used to read configuration file, extent report 
9. **config.json file:** contains configurations such as calculate Bill API url.

**Framework best practices are followed as below:** 
1. Steps in the feature file are designed for maximum reusability.
2. Constants are maintained in a separate class.
3. Configurations fetched from the config file such as API url etc.
4. Design principles such as oops principles, dependency injection, separation of concern.


   
