use BlogSharp2025
go

-- Insert a cooking blog author
INSERT INTO Author (Email, PasswordHash, BlogTitle) 
VALUES ('chef.maria@cookingblog.com', '$2a$12$LQv3c1yqBwLVzjzVfOaFeOGXmO/b.6n2z2d5F2M5x5o8m6s3l1qEm', 'Maria''s Kitchen Adventures');

-- Declare variable to store the author ID for use in blog posts
DECLARE @MariaAuthorId INT = SCOPE_IDENTITY();

-- Insert five cooking/recipe blog posts
INSERT INTO BlogPost (Title, TextBody, CreationDate, FK_Author_Id) VALUES 
('Perfect Homemade Pizza Dough Recipe', 
'Creating the perfect pizza dough from scratch is easier than you think! This recipe yields a beautifully elastic dough with amazing flavor. Start with 3 cups of bread flour, 1 tsp salt, 1 tbsp sugar, and 1 packet of active dry yeast. Mix warm water (110°F) with the yeast and sugar, let it foam for 5 minutes. Combine dry ingredients, add the yeast mixture and olive oil. Knead for 8-10 minutes until smooth and elastic. Let rise for 1-2 hours until doubled in size. This dough can be used immediately or stored in the refrigerator for up to 3 days for even better flavor development.',
'2024-11-01 14:30:00',
@MariaAuthorId),

('Classic Chicken Parmesan - Restaurant Quality', 
'This restaurant-style Chicken Parmesan will become your go-to comfort food recipe. Pound chicken breasts to even thickness, season with salt and pepper. Set up a breading station: flour, beaten eggs with a splash of milk, and seasoned breadcrumbs mixed with parmesan cheese. Coat each piece thoroughly and pan-fry in olive oil until golden brown. Top with marinara sauce and mozzarella cheese, then bake at 425°F for 15-20 minutes until cheese is bubbly and golden. Serve over pasta with fresh basil and extra parmesan. The key is not overcooking the chicken - it should be juicy and tender inside with a crispy coating.',
'2024-11-03 16:45:00',
@MariaAuthorId),

('Decadent Chocolate Lava Cake in 15 Minutes', 
'Impress your guests with this foolproof chocolate lava cake that takes only 15 minutes from start to finish! Melt 4 oz dark chocolate with 4 tbsp butter in the microwave. Whisk in 2 eggs, 2 tbsp sugar, pinch of salt, and 2 tbsp flour until just combined - don''t overmix! Butter and dust ramekins with cocoa powder, divide batter evenly. Bake at 425°F for exactly 12-14 minutes. The edges should be firm but center slightly jiggly. Let cool for 1 minute, then run a knife around edges and invert onto plates. Dust with powdered sugar and serve immediately with vanilla ice cream. The molten center is pure magic!',
'2024-11-05 19:20:00',
@MariaAuthorId),

('Fresh Herb Garden Pasta Salad for Summer', 
'This vibrant pasta salad celebrates the best of summer herbs and vegetables. Cook 1 lb penne pasta al dente, drain and rinse with cold water. Combine with halved cherry tomatoes, diced cucumber, red onion, and crumbled feta cheese. For the dressing, whisk together olive oil, lemon juice, minced garlic, and fresh herbs - basil, oregano, and parsley work beautifully together. Season with salt and pepper, toss everything together and chill for at least 2 hours. The flavors develop and meld together perfectly. Add fresh herbs just before serving for the brightest flavor. Perfect for potlucks, picnics, or light summer dinners.',
'2024-11-07 11:15:00',
@MariaAuthorId),

('Asian-Style Beef and Broccoli Stir Fry', 
'Skip the takeout and make this healthier, more flavorful beef and broccoli at home! Slice 1 lb flank steak against the grain into thin strips. Marinate in soy sauce, cornstarch, and a touch of oil for 15 minutes. Heat wok or large skillet over high heat, cook beef in batches until just done - don''t overcrowd! Remove beef, add broccoli florets with a splash of water, cover and steam for 2 minutes. Return beef to pan with sauce made from soy sauce, oyster sauce, garlic, ginger, and a cornstarch slurry. Everything comes together in under 20 minutes. Serve over steamed rice with sesame seeds and green onions.',
'2024-11-09 13:00:00',
@MariaAuthorId);

-- Insert Python programming blog author
INSERT INTO Author (Email, PasswordHash, BlogTitle) 
VALUES ('alex.python@codemaster.dev', '$2a$12$LQv3c1yqBwLVzjzVfOaFeOGXmO/b.6n2z2d5F2M5x5o8m6s3l1qEm', 'Python Code Mastery');

-- Declare variable to store the Python author ID
DECLARE @PythonAuthorId INT = SCOPE_IDENTITY();

-- Insert eight Python programming blog posts
INSERT INTO BlogPost (Title, TextBody, CreationDate, FK_Author_Id) VALUES 
('Python Basics: Variables and Data Types Explained', 
'Understanding Python''s fundamental data types is crucial for any beginner. Python supports several built-in data types: integers (int), floating-point numbers (float), strings (str), booleans (bool), lists, tuples, dictionaries, and sets. Variables in Python are dynamically typed, meaning you don''t need to declare their type explicitly. For example: name = "John" creates a string, age = 25 creates an integer, and is_student = True creates a boolean. Python''s duck typing philosophy means "if it walks like a duck and quacks like a duck, it''s a duck." This flexibility makes Python incredibly powerful for rapid development and prototyping.',
'2024-10-15 09:00:00',
@PythonAuthorId),

('Mastering Python List Comprehensions', 
'List comprehensions are one of Python''s most elegant features, allowing you to create lists in a concise and readable way. The basic syntax is [expression for item in iterable if condition]. For example, squares = [x**2 for x in range(10)] creates a list of squares from 0 to 81. You can add conditions: even_squares = [x**2 for x in range(10) if x % 2 == 0]. Nested comprehensions are possible but use them sparingly for readability. List comprehensions are generally faster than equivalent for loops and more Pythonic. They can replace map(), filter(), and reduce() in many cases, making your code more readable and maintainable.',
'2024-10-18 14:30:00',
@PythonAuthorId),

('Object-Oriented Programming in Python', 
'Python''s OOP implementation is clean and intuitive. Classes are defined using the class keyword, and methods are just functions defined inside a class. The __init__ method is the constructor, called when creating new instances. Use self to refer to the instance within methods. Inheritance is achieved by passing the parent class as a parameter: class Dog(Animal). Python supports multiple inheritance, but use it carefully to avoid the diamond problem. Properties can be created using @property decorator for getter methods and @property_name.setter for setters. Encapsulation is achieved through naming conventions: _private (convention) and __really_private (name mangling).',
'2024-10-22 11:15:00',
@PythonAuthorId),

('Python Decorators: Enhancing Functions with Style', 
'Decorators are a powerful Python feature that allows you to modify or enhance functions without changing their code. They use the @ symbol and are applied above function definitions. The basic pattern is defining a wrapper function that takes a function as argument and returns a modified version. Common use cases include logging, timing, authentication, and caching. Built-in decorators like @staticmethod, @classmethod, and @property are frequently used. You can create decorators with parameters using nested functions or classes. Functools.wraps should be used to preserve the original function''s metadata. Decorators make code more modular and follow the DRY principle.',
'2024-10-25 16:45:00',
@PythonAuthorId),

('Working with Python Virtual Environments', 
'Virtual environments are essential for Python development, allowing you to manage dependencies for different projects separately. Use python -m venv myenv to create a virtual environment, then activate it with source myenv/bin/activate (Linux/Mac) or myenv\Scripts\activate (Windows). Install packages with pip install package_name and freeze dependencies with pip freeze > requirements.txt. Other developers can recreate your environment using pip install -r requirements.txt. Tools like pipenv and conda provide additional features and easier management. Always use virtual environments to avoid dependency conflicts and ensure reproducible deployments. Never install packages globally for project-specific needs.',
'2024-10-28 13:20:00',
@PythonAuthorId),

('Error Handling and Exceptions in Python', 
'Python uses try/except blocks for error handling, making your code more robust and user-friendly. Common exceptions include ValueError, TypeError, KeyError, and IndexError. Use specific exceptions rather than bare except clauses. The else clause runs when no exception occurs, while finally always executes for cleanup. You can raise custom exceptions with raise ExceptionType("message"). Create custom exception classes by inheriting from Exception. Use multiple except blocks for different exception types. The with statement ensures proper resource cleanup and is preferred for file operations. Logging errors is better than silently catching them - use the logging module for production code.',
'2024-11-01 10:30:00',
@PythonAuthorId),

('Python File I/O and Working with APIs', 
'File operations in Python are straightforward using the open() function. Always use context managers (with statement) to ensure proper file closure. Read files with read(), readline(), or readlines() methods. Write with write() or writelines(). For APIs, the requests library is the standard choice. Use requests.get(), post(), put(), delete() for different HTTP methods. Handle JSON responses with response.json(). Always check status codes and handle network errors gracefully. For authentication, use headers or built-in auth methods. Rate limiting and retries are important for production API usage. Consider using async libraries like aiohttp for high-performance applications.',
'2024-11-04 15:15:00',
@PythonAuthorId),

('Advanced Python: Generators and Iterators', 
'Generators are memory-efficient tools for creating iterators using yield instead of return. They produce values on-demand, making them perfect for large datasets. Generator expressions use parentheses: (x**2 for x in range(1000000)). They''re lazy, meaning values are computed only when needed. Iterators implement __iter__() and __next__() methods. The itertools module provides powerful tools for creating and combining iterators. Use generators for reading large files, infinite sequences, or when memory usage is critical. They''re excellent for data pipelines and processing streams. Understanding generators is key to writing efficient Python code and is fundamental to many advanced Python patterns.',
'2024-11-07 12:00:00',
@PythonAuthorId);

-- Insert technology blog author
INSERT INTO Author (Email, PasswordHash, BlogTitle) 
VALUES ('sarah.tech@digitaltrends.com', '$2a$12$LQv3c1yqBwLVzjzVfOaFeOGXmO/b.6n2z2d5F2M5x5o8m6s3l1qEm', 'Digital Horizons');

-- Declare variable to store the tech author ID
DECLARE @TechAuthorId INT = SCOPE_IDENTITY();

-- Insert technology blog posts
INSERT INTO BlogPost (Title, TextBody, CreationDate, FK_Author_Id) VALUES 
('The Rise of AI in Everyday Applications', 
'Artificial Intelligence has quietly integrated into our daily lives in ways we might not even notice. From recommendation algorithms on streaming platforms to smart home devices that learn our preferences, AI is reshaping how we interact with technology. Voice assistants like Siri and Alexa use natural language processing to understand and respond to our queries. Email spam filters employ machine learning to identify unwanted messages. Even our smartphones use AI for photo enhancement, predictive text, and battery optimization. The next wave includes autonomous vehicles, personalized healthcare, and smart city infrastructure. As AI becomes more sophisticated, the line between human and machine decision-making continues to blur.',
'2024-10-20 08:45:00',
@TechAuthorId),

('Cybersecurity in the Remote Work Era', 
'The shift to remote work has fundamentally changed the cybersecurity landscape. Traditional perimeter-based security models are no longer sufficient when employees access company resources from home networks, coffee shops, and co-working spaces. Zero-trust architecture has become the new standard, requiring verification for every user and device. VPNs, multi-factor authentication, and endpoint protection are now essential tools. Phishing attacks have increased dramatically, targeting remote workers with sophisticated social engineering tactics. Companies must invest in employee training, secure cloud infrastructure, and robust incident response plans. The human element remains the weakest link in cybersecurity, making ongoing education and awareness programs critical for organizational security.',
'2024-10-24 14:20:00',
@TechAuthorId),

('Sustainable Technology: Green Computing Revolution', 
'The tech industry is undergoing a green revolution as companies recognize their environmental responsibility. Data centers, which consume about 1% of global electricity, are transitioning to renewable energy sources. Cloud providers like Google and Microsoft have committed to carbon neutrality. Hardware manufacturers are designing more energy-efficient processors and using recycled materials. Software optimization plays a crucial role - efficient code reduces computational requirements and energy consumption. The concept of "green software engineering" emphasizes writing code that minimizes resource usage. Blockchain technologies are exploring proof-of-stake alternatives to energy-intensive proof-of-work systems. As consumers become more environmentally conscious, sustainable technology practices are becoming competitive advantages rather than just corporate social responsibility initiatives.',
'2024-10-30 11:30:00',
@TechAuthorId);