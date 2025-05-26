-- Down script

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
    WHERE CONSTRAINT_NAME='fk_recipes_recipe_user_id')
    ALTER TABLE recipes DROP CONSTRAINT fk_recipes_recipe_user_id

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
    WHERE CONSTRAINT_NAME='fk_recipes_recipe_category_id')
    ALTER TABLE recipes DROP CONSTRAINT fk_recipes_recipe_category_id

DROP TABLE IF EXISTS recipes

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
    WHERE CONSTRAINT_NAME='fk_ingredients_ingredient_recipe_id')
    ALTER TABLE ingredients DROP CONSTRAINT fk_ingredients_ingredient_recipe_id

DROP TABLE IF EXISTS ingredients

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
    WHERE CONSTRAINT_NAME='fk_ratings_rating_user_id')
    ALTER TABLE ratings DROP CONSTRAINT fk_ratings_rating_user_id

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
    WHERE CONSTRAINT_NAME='fk_ratings_rating_recipe_id')
    ALTER TABLE ratings DROP CONSTRAINT fk_ratings_rating_recipe_id

DROP TABLE IF EXISTS ratings

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
    WHERE CONSTRAINT_NAME='fk_comments_comment_user_id')
    ALTER TABLE comments DROP CONSTRAINT fk_comments_comment_user_id

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
    WHERE CONSTRAINT_NAME='fk_comments_comment_recipe_id')
    ALTER TABLE comments DROP CONSTRAINT fk_comments_comment_recipe_id

DROP TABLE IF EXISTS comments

DROP TABLE IF EXISTS categories

DROP TABLE IF EXISTS users

DROP DATABASE IF EXISTS recipe_manager
USE master
GO
IF EXISTS(SELECT NAME FROM sys.databases WHERE NAME = 'recpe_manager')
    ALTER DATABASE recipe_manager SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
DROP DATABASE IF EXISTS recipe_manager
GO

-- Up script

CREATE DATABASE recipe_manager

CREATE TABLE users (
    user_id INT IDENTITY NOT NULL,
	user_email VARCHAR(50) NOT NULL,
    user_password VARCHAR(50) NOT NULL,
    user_name VARCHAR(50) NOT NULL,
    CONSTRAINT pk_users_user_id PRIMARY KEY (user_id),
    CONSTRAINT u_users_user_email UNIQUE (user_email)
)

CREATE TABLE categories (
    category_id INT IDENTITY NOT NULL,
    category_name VARCHAR(50) NOT NULL,
    CONSTRAINT pk_categories_category_id PRIMARY KEY (category_id)
)

CREATE TABLE recipes (
    recipe_id INT IDENTITY NOT NULL,
    recipe_title VARCHAR(50) NOT NULL,
    recipe_description VARCHAR(100) NULL,
    instructions VARCHAR(200) NOT NULL,
    preparation_time INT NOT NULL,
    cooking_time INT NOT NULL,
    total_time AS (preparation_time + cooking_time),
    difficulty_level VARCHAR(50) NOT NULL,
    recipe_user_id INT NOT NULL,
    recipe_category_id INT NOT NULL,
    CONSTRAINT pk_recipes_recipe_id PRIMARY KEY (recipe_id),
    CONSTRAINT fk_recipes_recipe_user_id FOREIGN KEY (recipe_user_id) REFERENCES users(user_id),
    CONSTRAINT fk_recipes_recipe_category_id FOREIGN KEY (recipe_category_id) REFERENCES categories(category_id)
)

CREATE TABLE ingredients (
    ingredient_id INT IDENTITY NOT NULL,
    ingredient_name VARCHAR(50) NOT NULL,
    ingredient_quantity VARCHAR(50) NOT NULL,
    ingredient_recipe_id INT NOT NULL,
    CONSTRAINT pk_ingredients_ingredient_id PRIMARY KEY (ingredient_id),
    CONSTRAINT fk_ingredients_ingredient_recipe_id FOREIGN KEY (ingredient_recipe_id) REFERENCES recipes(recipe_id)
)

CREATE TABLE ratings (
    rating_id INT IDENTITY NOT NULL,
    rating_score INT NOT NULL,
    rating_user_id INT NOT NULL,
    rating_recipe_id INT NOT NULL,
    CONSTRAINT pk_ratings_rating_id PRIMARY KEY (rating_id),
    CONSTRAINT fk_ratings_rating_user_id FOREIGN KEY (rating_user_id) REFERENCES users(user_id),
    CONSTRAINT fk_ratings_rating_recipe_id FOREIGN KEY (rating_recipe_id) REFERENCES recipes(recipe_id)
)

CREATE TABLE comments (
    comment_id INT IDENTITY NOT NULL,
    comment_text VARCHAR(200) NOT NULL,
    comment_timestamp DATETIME NOT NULL,
    comment_user_id INT NOT NULL,
    comment_recipe_id INT NOT NULL,
    CONSTRAINT pk_comments_comment_id PRIMARY KEY (comment_id),
    CONSTRAINT fk_comments_comment_user_id FOREIGN KEY (comment_user_id) REFERENCES users(user_id),
    CONSTRAINT fk_comments_comment_recipe_id FOREIGN KEY (comment_recipe_id) REFERENCES recipes(recipe_id)
)

-- Insert data for users table
INSERT INTO users (user_name, user_password, user_email)
VALUES
    ('JohnDoe', 'password123', 'john.doe@gmail.com'),
    ('JaneSmith', 'securepass', 'jane.smith@gmail.com'),
    ('AliceJohnson', 'pass123', 'alice.j@gmail.com'),
    ('BobSmith', 'securepass', 'bob.smith@gmail.com'),
    ('EvaDavis', 'evapass', 'eva.d@gmail.com'),
    ('SamWilson', 'sam123', 'sam.w@gmail.com'),
    ('OliviaBrown', 'olivia_pass', 'olivia.b@gmail.com'),
    ('CharlieWhite', 'charliepass', 'charlie.w@gmail.com'),
    ('GraceMiller', 'gracepass', 'grace.m@gmail.com'),
    ('DanielHarris', 'daniel_pass', 'daniel.h@gmail.com'),
    ('EmmaThomas', 'emma_pass', 'emma.t@gmail.com'),
    ('LiamRobinson', 'liam_pass', 'liam.r@gmail.com'),
    ('SophiaWalker', 'sophia_pass', 'sophia.w@gmail.com'),
    ('MasonHall', 'mason_pass', 'mason.h@gmail.com'),
    ('AvaTurner', 'ava_pass', 'ava.t@gmail.com'),
    ('NoahClark', 'noah_pass', 'noah.c@gmail.com'),
    ('IsabellaBaker', 'isabella_pass', 'isabella.b@gmail.com'),
    ('EthanLewis', 'ethan_pass', 'ethan.l@gmail.com'),
    ('MiaWright', 'mia_pass', 'mia.w@gmail.com'),
    ('LiamAnderson', 'liam_pass', 'liam.a@gmail.com'),
    ('OliviaWilson', 'olivia_pass', 'olivia.w@gmail.com'),
    ('LucasDavis', 'lucas_pass', 'lucas.d@gmail.com'),
    ('AvaMartinez', 'ava_pass', 'ava.m@gmail.com'),
    ('LoganTaylor', 'logan_pass', 'logan.t@gmail.com'),
    ('SophiaTurner', 'sophia_pass', 'sophia.t@gmail.com'),
    ('ElijahMoore', 'elijah_pass', 'elijah.m@gmail.com'),
    ('AveryGarcia', 'avery_pass', 'avery.g@gmail.com'),
    ('HarperScott', 'harper_pass', 'harper.s@gmail.com'),
    ('CarterCooper', 'carter_pass', 'carter.c@gmail.com'),
    ('MadisonMurphy', 'madison_pass', 'madison.m@gmail.com')

-- Insert data for categories table
INSERT INTO categories (category_name)
VALUES
    ('Breakfast'),
    ('Appetizer'),
    ('Main Course'),
    ('Dessert'),
    ('Beverage')

-- Insert data for recipes table
INSERT INTO recipes (recipe_title, recipe_description, instructions, preparation_time, cooking_time, difficulty_level, recipe_user_id, recipe_category_id)
VALUES
    ('Pancakes', 'Classic breakfast pancakes', '1. Mix ingredients, 2. Pour batter on hot griddle, 3. Flip and cook', 15, 10, 'Easy', 1, 1),
    ('Spinach Dip', 'Creamy spinach dip for starters', '1. Mix spinach with cream cheese, 2. Bake until bubbly, 3. Serve with chips', 25, 20, 'Intermediate', 2, 2),
    ('Chicken Alfredo', 'Rich and creamy pasta dish', '1. Cook chicken, 2. Prepare Alfredo sauce, 3. Combine with pasta', 30, 20, 'Intermediate', 1, 3),
    ('Chocolate Cake', 'Decadent chocolate cake', '1. Mix dry and wet ingredients, 2. Bake in preheated oven, 3. Frost and enjoy', 25, 30, 'Advanced', 2, 4),
    ('Iced Coffee', 'Refreshing cold coffee', '1. Brew coffee, 2. Chill, 3. Serve over ice with milk and sweetener', 10, 5, 'Easy', 1, 5),
    ('Omelette', 'Classic fluffy omelette with various fillings', '1. Beat eggs, 2. Pour into a hot skillet, 3. Add desired fillings, 4. Fold and serve', 10, 15, 'Easy', 2, 1),
    ('Caprese Salad', 'Fresh salad with tomatoes, mozzarella, and basil', '1. Slice tomatoes and mozzarella, 2. Arrange with basil leaves, 3. Drizzle with balsamic glaze', 15, 0, 'Easy', 3, 2),
    ('Grilled Salmon', 'Healthy grilled salmon fillets', '1. Season salmon, 2. Grill until cooked, 3. Serve with lemon wedges', 20, 15, 'Intermediate', 1, 3),
    ('Tiramisu', 'Classic Italian dessert with layers of coffee-soaked ladyfingers and mascarpone cream', '1. Dip ladyfingers in coffee, 2. Layer with mascarpone mixture, 3. Refrigerate and dust with cocoa', 40, 0, 'Advanced', 2, 4),
    ('Mango Smoothie', 'Refreshing smoothie with mango, yogurt, and banana', '1. Blend mango, yogurt, and banana until smooth, 2. Pour into a glass and enjoy', 0, 10, 'Easy', 3, 5),
    ('French Toast', 'Cinnamon-flavored French toast with syrup', '1. Dip bread in a mixture of eggs and cinnamon, 2. Cook until golden brown, 3. Serve with syrup', 15, 10, 'Easy', 1, 1),
    ('Shrimp Scampi', 'Garlicky shrimp in a buttery white wine sauce', '1. Saute garlic in butter, 2. Add shrimp and white wine, 3. Serve over pasta', 20, 15, 'Intermediate', 2, 3),
    ('Blueberry Muffins', 'Homemade muffins bursting with fresh blueberries', '1. Mix dry and wet ingredients, 2. Fold in blueberries, 3. Bake until golden brown', 20, 25, 'Intermediate', 3, 1),
    ('Beef Stir-Fry', 'Quick and flavorful beef stir-fry with vegetables', '1. Slice beef and vegetables, 2. Stir-fry in a hot pan, 3. Serve over rice', 15, 15, 'Intermediate', 1, 3),
    ('Cheesecake', 'Classic New York-style cheesecake with a graham cracker crust', '1. Mix cream cheese and sugar, 2. Bake in a water bath, 3. Chill before serving', 30, 45, 'Advanced', 3, 4),
    ('Mint Lemonade', 'Refreshing mint-infused lemonade', '1. Mix lemon juice, mint, and sugar, 2. Add cold water and ice, 3. Stir and enjoy', 0, 10, 'Easy', 2, 5),
	('Vegetarian Burritos', 'Hearty burritos with beans, rice, and veggies', '1. Cook rice and beans, 2. Assemble burritos with desired fillings, 3. Roll and serve', 20, 15, 'Intermediate', 3, 3),
    ('Lemon Garlic Roast Chicken', 'Juicy roast chicken with a zesty lemon and garlic marinade', '1. Marinate chicken in lemon and garlic, 2. Roast until golden brown, 3. Carve and enjoy', 30, 40, 'Intermediate', 1, 3),
    ('Fruit Salad', 'Colorful fruit salad with a honey-lime dressing', '1. Chop assorted fruits, 2. Toss with honey-lime dressing, 3. Chill and serve', 15, 0, 'Easy', 2, 2),
    ('Shrimp Tacos', 'Spicy shrimp tacos with avocado and cilantro', '1. Season shrimp with spices, 2. Cook until opaque, 3. Assemble tacos with avocado and cilantro', 25, 15, 'Intermediate', 3, 1),
    ('Chocolate Chip Cookies', 'Classic chocolate chip cookies with a soft and chewy texture', '1. Cream butter and sugar, 2. Mix in dry ingredients and chocolate chips, 3. Bake until golden', 15, 12, 'Easy', 1, 4),
    ('Cobb Salad', 'Hearty salad with grilled chicken, bacon, and blue cheese', '1. Grill chicken and cook bacon, 2. Arrange lettuce and toppings, 3. Drizzle with dressing', 20, 0, 'Intermediate', 2, 2),
    ('Beef and Broccoli Stir-Fry', 'Quick stir-fry with tender beef and broccoli in a savory sauce', '1. Slice beef and blanch broccoli, 2. Stir-fry in a hot wok, 3. Serve over rice', 20, 15, 'Intermediate', 3, 3),
    ('Raspberry Cheesecake Bars', 'Delicious cheesecake bars with a raspberry swirl', '1. Prepare graham cracker crust, 2. Mix cream cheese and raspberry puree, 3. Bake until set', 25, 30, 'Intermediate', 1, 4),
    ('Mango Salsa', 'Fresh and tangy mango salsa with tomatoes and cilantro', '1. Dice mango and tomatoes, 2. Mix with cilantro and lime juice, 3. Serve with tortilla chips', 0, 10, 'Easy', 2, 2),
    ('Vegetable Lasagna', 'Layered lasagna with a variety of colorful vegetables', '1. Roast and layer vegetables, 2. Assemble with pasta and cheese, 3. Bake until bubbly', 30, 35, 'Intermediate', 3, 3),
	('Crispy Baked Chicken Wings', 'Golden and crispy baked chicken wings with a variety of sauces', '1. Coat wings in a seasoned flour mixture, 2. Bake until crispy, 3. Toss in your favorite sauce', 15, 30, 'Intermediate', 1, 3),
    ('Pineapple Upside-Down Cake', 'Classic dessert with caramelized pineapple and maraschino cherries', '1. Arrange pineapple and cherries in a pan, 2. Pour cake batter over, 3. Bake and invert to serve', 30, 40, 'Intermediate', 2, 4),
    ('Greek Salad', 'Refreshing salad with tomatoes, cucumbers, olives, and feta cheese', '1. Dice vegetables and toss with olives and feta, 2. Drizzle with olive oil and lemon juice, 3. Serve chilled', 15, 0, 'Easy', 3, 2),
	('Quinoa Salad', 'Healthy salad with quinoa, cherry tomatoes, and cucumbers', '1. Cook quinoa, 2. Mix with diced vegetables, 3. Toss with vinaigrette dressing', 20, 0, 'Easy', 3, 2),
    ('BBQ Pulled Pork Sandwiches', 'Slow-cooked pulled pork with barbecue sauce on a bun', '1. Season pork and slow-cook, 2. Shred and mix with barbecue sauce, 3. Serve on a bun', 30, 6, 'Intermediate', 1, 3),
    ('Mushroom Risotto', 'Creamy and flavorful risotto with sautéed mushrooms', '1. Sauté mushrooms and onions, 2. Toast rice and add broth gradually, 3. Stir in Parmesan cheese', 25, 30, 'Intermediate', 2, 3),
    ('Banana Bread', 'Moist and delicious banana bread with walnuts', '1. Mash bananas and mix with other ingredients, 2. Fold in walnuts, 3. Bake until golden brown', 15, 50, 'Easy', 1, 4),
    ('Mediterranean Stuffed Peppers', 'Colorful bell peppers stuffed with quinoa, olives, and feta', '1. Cook quinoa and mix with olives and feta, 2. Stuff peppers and bake until tender, 3. Serve hot', 30, 25, 'Intermediate', 2, 3),
    ('Lemon Blueberry Pancakes', 'Fluffy pancakes with fresh blueberries and a hint of lemon', '1. Mix batter with blueberries and lemon zest, 2. Cook on a griddle until golden, 3. Serve with syrup', 20, 15, 'Intermediate', 3, 1),
    ('Cajun Shrimp Pasta', 'Spicy and flavorful shrimp pasta with a Cajun cream sauce', '1. Sauté shrimp with Cajun seasoning, 2. Prepare cream sauce, 3. Toss with cooked pasta', 25, 20, 'Intermediate', 1, 3),
    ('Tomato Basil Bruschetta', 'Classic bruschetta with diced tomatoes, fresh basil, and garlic', '1. Dice tomatoes and mix with chopped basil and garlic, 2. Spoon onto toasted baguette slices, 3. Drizzle with balsamic glaze', 15, 0, 'Easy', 2, 2),
    ('Chicken Fajitas', 'Sizzling chicken fajitas with colorful bell peppers and onions', '1. Marinate chicken and sauté with peppers and onions, 2. Serve with tortillas and toppings', 20, 15, 'Intermediate', 3, 1),
    ('Pesto Pasta with Cherry Tomatoes', 'Pasta tossed in a basil pesto sauce with burst cherry tomatoes', '1. Cook pasta and toss with pesto, 2. Sauté cherry tomatoes until burst, 3. Mix and serve', 20, 15, 'Easy', 1, 3),
	('Hawaiian Pizza', 'Pizza topped with ham, pineapple, and mozzarella cheese', '1. Roll out pizza dough, 2. Spread tomato sauce, ham, pineapple, and cheese, 3. Bake until golden brown', 25, 15, 'Intermediate', 2, 3),
    ('Baked Ziti', 'Classic baked pasta dish with ziti, marinara sauce, and melted cheese', '1. Cook ziti and mix with marinara sauce, 2. Layer with mozzarella cheese, 3. Bake until bubbly', 30, 25, 'Intermediate', 3, 3),
    ('Cucumber Mint Cooler', 'Refreshing drink with cucumber, mint, and lime', '1. Blend cucumber, mint, and lime juice, 2. Strain and serve over ice, 3. Garnish with mint leaves', 0, 10, 'Easy', 1, 5),
	('Stuffed Mushrooms', 'Mushroom caps filled with a savory mixture of breadcrumbs and herbs', '1. Remove stems from mushrooms, 2. Mix breadcrumbs with herbs, 3. Stuff mushrooms and bake', 20, 15, 'Intermediate', 2, 2),
    ('Teriyaki Salmon', 'Grilled salmon glazed with a sweet teriyaki sauce', '1. Marinate salmon in teriyaki sauce, 2. Grill until cooked, 3. Garnish with sesame seeds and green onions', 25, 15, 'Intermediate', 3, 3),
    ('Pumpkin Soup', 'Creamy soup made with roasted pumpkin and warming spices', '1. Roast pumpkin, 2. Blend with broth and spices, 3. Simmer and serve hot', 30, 25, 'Intermediate', 1, 2),
    ('Cherry Almond Granola', 'Homemade granola with dried cherries and almonds', '1. Mix oats with honey and almonds, 2. Bake until golden brown, 3. Stir in dried cherries', 15, 30, 'Easy', 2, 5),
    ('Crispy Tofu Stir-Fry', 'Crispy tofu cubes stir-fried with colorful vegetables', '1. Press and coat tofu with cornstarch, 2. Stir-fry with vegetables, 3. Toss in a flavorful sauce', 20, 20, 'Intermediate', 3, 3),
    ('Peach Cobbler', 'Classic Southern dessert with sweet peaches and a buttery biscuit topping', '1. Mix peaches with sugar and spices, 2. Top with biscuit dough, 3. Bake until golden brown', 30, 40, 'Intermediate', 1, 4),
    ('Avocado Toast', 'Sliced avocado on toasted bread with various toppings', '1. Mash avocado and spread on toasted bread, 2. Add toppings like cherry tomatoes or poached eggs, 3. Season and enjoy', 10, 5, 'Easy', 2, 5),
    ('Chicken Parmesan', 'Breaded and baked chicken breasts topped with marinara sauce and melted cheese', '1. Bread chicken, 2. Bake until crispy, 3. Top with marinara and cheese, then bake until bubbly', 25, 25, 'Intermediate', 3, 3)

-- Insert data for ingredients table
INSERT INTO ingredients (ingredient_name, ingredient_quantity, ingredient_recipe_id)
VALUES
    ('Flour', '2 cups', 1),
    ('Milk', '1 cup', 1),
    ('Eggs', '2', 1),
    ('Butter', '2 tablespoons', 1),
    ('Spinach', '1 cup', 2),
    ('Cream Cheese', '8 oz', 2),
    ('Chips', 'for serving', 2),
    ('Chicken', '1 lb', 3),
    ('Alfredo Sauce', '1 cup', 3),
    ('Pasta', '8 oz', 3),
    ('Cocoa Powder', '1/2 cup', 4),
    ('Sugar', '2 cups', 4),
    ('Baking Powder', '1 teaspoon', 4),
    ('Coffee', '2 cups', 5),
    ('Ice', 'as needed', 5),
    ('Milk', '1/2 cup', 5),
    ('Eggs', '2', 6),
    ('Fillings of your choice', 'as desired', 6),
    ('Tomatoes', '3', 7),
    ('Mozzarella Cheese', '8 oz', 7),
    ('Basil Leaves', 'a handful', 7),
    ('Balsamic Glaze', 'for drizzling', 7),
    ('Salmon Fillets', '4', 8),
    ('Lemon Wedges', 'for serving', 8),
    ('Ladyfingers', '24', 9),
    ('Mascarpone Cream', '16 oz', 9),
    ('Cocoa Powder', 'for dusting', 9),
    ('Mango', '1', 10),
    ('Yogurt', '1 cup', 10),
    ('Banana', '1', 10),
    ('Bread Slices', '4', 11),
    ('Cinnamon', '1 teaspoon', 11),
    ('Syrup', 'for serving', 11),
    ('Shrimp', '1 lb', 12),
    ('Garlic', '4 cloves', 12),
    ('Butter', '1/2 cup', 12),
    ('White Wine', '1/2 cup', 12),
    ('Blueberries', '1 cup', 13),
    ('Flour', '2 cups', 13),
    ('Sugar', '1 cup', 13),
    ('Beef', '1 lb', 14),
    ('Vegetables', 'assorted', 14),
    ('Rice', 'for serving', 14),
    ('Cream Cheese', '16 oz', 15),
    ('Sugar', '1 cup', 15),
    ('Mint', 'a handful', 16),
    ('Lemon Juice', '1/2 cup', 16),
    ('Tortillas', '4', 16),
    ('Rice', '1 cup', 17),
    ('Beans', '1 cup', 17),
    ('Assorted Veggies', 'as desired', 17),
    ('Chicken', '1 whole', 18),
    ('Lemon', '1', 18),
    ('Fruits', 'assorted', 19),
    ('Honey', '1/4 cup', 19),
    ('Lime Juice', '2 tablespoons', 19),
    ('Shrimp', '1 lb', 20),
    ('Taco Shells', '4', 20),
    ('Avocado', '2', 20),
    ('Chocolate Chips', '1 cup', 21),
    ('Butter', '1/2 cup', 21),
    ('Sugar', '1 cup', 21),
    ('Cream Cheese', '16 oz', 21),
    ('Lettuce', '1 head', 22),
    ('Grilled Chicken', '1 lb', 22),
    ('Bacon', '6 slices', 22),
    ('Blue Cheese', '1 cup', 22),
    ('Beef', '1 lb', 23),
    ('Broccoli', '1 head', 23),
    ('Soy Sauce', '1/4 cup', 23),
    ('Cheese', '1 cup', 24),
    ('Raspberry Puree', '1/2 cup', 24),
    ('Graham Cracker Crust', '1', 24),
    ('Mango', '1', 25),
    ('Tomatoes', '2', 25),
    ('Cilantro', 'a handful', 25),
    ('Lime Juice', '1 tablespoon', 25),
    ('Lasagna Noodles', '9', 26),
    ('Vegetables', 'assorted', 26),
    ('Cheese', '2 cups', 26),
    ('Chicken Wings', '2 lbs', 27),
    ('Flour', '1 cup', 27),
    ('Seasonings', 'as desired', 27),
    ('Sauce', 'of your choice', 27),
    ('Pineapple Slices', '1 can', 28),
    ('Maraschino Cherries', '1 jar', 28),
    ('Cake Batter', 'as needed', 28),
    ('Tomatoes', '2', 29),
    ('Cucumbers', '2', 29),
    ('Olives', '1 cup', 29),
    ('Feta Cheese', '1 cup', 29),
    ('Quinoa', '1 cup', 30),
    ('Cherry Tomatoes', '1 cup', 30),
    ('Cucumbers', '1', 30),
    ('BBQ Sauce', '1 cup', 31),
    ('Pork', '2 lbs', 31),
    ('Buns', '4', 31),
    ('Mushrooms', '1 lb', 32),
    ('Onions', '2', 32),
    ('Risotto Rice', '1 cup', 33),
    ('Mushrooms', '1 cup', 33),
    ('Parmesan Cheese', '1/2 cup', 33),
    ('Bananas', '3', 34),
    ('Walnuts', '1/2 cup', 34),
    ('Cherries', '1 cup', 34),
    ('Tofu', '1 block', 35),
    ('Cornstarch', '1/2 cup', 35),
    ('Vegetables', 'assorted', 35),
    ('Peaches', '4 cups', 36),
    ('Biscuit Dough', '1 can', 36),
    ('Avocado', '2', 37),
    ('Bread Slices', '4', 37),
    ('Toppings', 'as desired', 37),
    ('Tomatoes', '4', 38),
    ('Basil', 'a handful', 38),
    ('Garlic', '3 cloves', 38),
    ('Chicken', '1 lb', 39),
    ('Bell Peppers', 'assorted colors', 39),
    ('Onions', '2', 39),
    ('Tortillas', '8', 39),
    ('Pesto Sauce', '1/2 cup', 40),
    ('Cherry Tomatoes', '1 cup', 40),
    ('Pasta', '8 oz', 40),
    ('Pizza Dough', '1 ball', 41),
    ('Ham', '1/2 cup', 41),
    ('Pineapple', '1/2 cup', 41),
    ('Mozzarella Cheese', '1 cup', 41),
    ('Ziti Pasta', '8 oz', 42),
    ('Marinara Sauce', '2 cups', 42),
    ('Mozzarella Cheese', '1 cup', 42),
    ('Cucumber', '1', 43),
    ('Mint', 'a handful', 43),
    ('Lime', '1', 43),
    ('Ice', 'as needed', 43),
    ('Mushrooms', '12', 44),
    ('Breadcrumbs', '1 cup', 44),
    ('Herbs', 'assorted', 44),
    ('Teriyaki Sauce', '1/2 cup', 45),
    ('Salmon Fillets', '4', 45),
    ('Sesame Seeds', 'for garnish', 45),
    ('Green Onions', 'for garnish', 45),
    ('Pumpkin', '1 small', 46),
    ('Vegetable Broth', '4 cups', 46),
    ('Spices', 'assorted', 46),
    ('Oats', '3 cups', 47),
    ('Honey', '1/2 cup', 47),
    ('Almonds', '1/2 cup', 47),
    ('Tofu', '1 block', 48),
    ('Cornstarch', '1/2 cup', 48),
    ('Vegetables', 'assorted', 48),
    ('Peaches', '4 cups', 49),
    ('Sugar', '1/2 cup', 49),
    ('Spices', 'assorted', 49),
    ('Avocado', '2', 50),
    ('Bread Slices', '4', 50),
    ('Toppings', 'as desired', 50)

-- Insert data for ratings table
INSERT INTO ratings (rating_score, rating_user_id, rating_recipe_id)
VALUES
    (3, 2, 1),
    (5, 3, 1),
    (4, 1, 1),
    (2, 3, 4),
    (4, 4, 6),
    (3, 5, 7),
    (5, 1, 8),
    (4, 2, 9),
    (2, 3, 10),
    (4, 4, 13),
    (3, 1, 13),
    (2, 2, 14),
    (5, 3, 15),
    (4, 4, 16),
    (3, 5, 17),
    (5, 1, 18),
    (4, 4, 21),
    (5, 5, 22),
    (3, 1, 23),
    (2, 2, 24),
    (5, 3, 24),
    (3, 1, 26),
    (4, 2, 27),
    (5, 3, 28),
    (3, 4, 29)

-- Insert data for comments table
INSERT INTO comments (comment_text, comment_timestamp, comment_user_id, comment_recipe_id)
VALUES
    ('These pancakes were amazing!', GETDATE(), 1, 1),
    ('I love the creamy texture of the spinach dip!', GETDATE(), 2, 2),
    ('The chicken alfredo was so rich and delicious.', GETDATE(), 3, 3),
    ('Chocolate cake is my weakness. This one didn''t disappoint!', GETDATE(), 4, 4),
    ('Iced coffee is perfect for any time of the day.', GETDATE(), 5, 5),
    ('Iced coffee is my go-to drink, especially on hot days. Love it!', GETDATE(), 2, 5),
    ('I added a splash of vanilla syrup to my iced coffee. Delicious!', GETDATE(), 4, 5),
    ('The omelette was fluffy and filled with tasty ingredients.', GETDATE(), 1, 6),
    ('Caprese salad is always a refreshing choice.', GETDATE(), 2, 7),
    ('Tiramisu is my favorite dessert of all time!', GETDATE(), 4, 9),
    ('Mango smoothie is so refreshing and easy to make.', GETDATE(), 5, 10),
    ('Cheesecake is always a crowd-pleaser.', GETDATE(), 5, 15),
    ('I made this cheesecake for a family gathering, and it was a hit!', GETDATE(), 3, 15),
    ('Mint lemonade is so refreshing, especially in summer.', GETDATE(), 1, 16),
    ('Vegetarian burritos are a favorite in my household.', GETDATE(), 2, 17),
    ('Shrimp tacos with avocado are simply irresistible.', GETDATE(), 5, 20),
    ('These chocolate chip cookies are the best I''ve ever had.', GETDATE(), 1, 21),
    ('Cobb salad is a satisfying and hearty meal.', GETDATE(), 2, 22),
    ('Beef and broccoli stir-fry is a quick weeknight dinner.', GETDATE(), 3, 23),
    ('Raspberry cheesecake bars are a delightful treat.', GETDATE(), 4, 24),
    ('Mango salsa is the perfect snack for a summer day.', GETDATE(), 5, 25),
    ('Chicken fajitas are a sizzling and flavorful option!', GETDATE(), 1, 38),
    ('Peach cobbler is a classic Southern dessert that never disappoints!', GETDATE(), 1, 39),
    ('Pesto pasta with cherry tomatoes is a quick and delicious meal!', GETDATE(), 1, 40),
    ('Hawaiian pizza brings a taste of the tropics to your table!', GETDATE(), 1, 41)

SELECT * FROM users
SELECT * FROM categories
SELECT * FROM recipes
SELECT * FROM ingredients
SELECT * FROM ratings
SELECT * FROM comments

-- Retrieve the ingredients for a specific recipe (in this case 'Iced Coffee')
SELECT r.recipe_title, i.ingredient_name, i.ingredient_quantity
FROM ingredients i
LEFT JOIN recipes r ON i.ingredient_recipe_id = r.recipe_id
WHERE r.recipe_title = 'Iced Coffee'

-- Retrieve the top-rated recipes in the specific category (in this case 'Dessert')
SELECT c.category_name, r.recipe_title, AVG(rt.rating_score) AS average_rating
FROM recipes r
JOIN ratings rt ON r.recipe_id = rt.rating_recipe_id
JOIN categories c ON r.recipe_category_id = c.category_id
WHERE c.category_name = 'Dessert'
GROUP BY c.category_name, r.recipe_title
ORDER BY average_rating DESC

-- Retrieve the usernames of users who have not submitted any recipes
SELECT u.user_name
FROM users u
LEFT JOIN recipes r ON u.user_id = r.recipe_user_id
WHERE r.recipe_id IS NULL

-- Retrieve users who have both rated and commented
SELECT DISTINCT u.user_name
FROM users u
LEFT JOIN comments c ON u.user_id = c.comment_user_id
LEFT JOIN ratings ra ON u.user_id = ra.rating_user_id
WHERE c.comment_recipe_id = ra.rating_recipe_id

-- Retrieve recipes with less than 3 ingredients
SELECT r.recipe_title, COUNT(i.ingredient_id) AS ingredient_count
FROM recipes r
LEFT JOIN ingredients i ON r.recipe_id = i.ingredient_recipe_id
GROUP BY r.recipe_id, r.recipe_title
HAVING COUNT(i.ingredient_id) < 3

-- Retrieve recipes with comments containing the word 'delicious'
SELECT r.recipe_title, c.comment_text
FROM recipes r
LEFT JOIN comments c ON r.recipe_id = c.comment_recipe_id
WHERE LOWER(c.comment_text) LIKE '%delicious%'

-- Retrieve the most recent 5 comments
SELECT TOP 5 c.comment_text, c.comment_timestamp,  u.user_name, r.recipe_title
FROM comments c
JOIN users u ON c.comment_user_id = u.user_id
JOIN recipes r ON c.comment_recipe_id = r.recipe_id
ORDER BY c.comment_timestamp DESC

-- Retreive the recipe with the shortest time to cook and prepare
SELECT recipe_title, preparation_time, cooking_time, total_time, difficulty_level
FROM recipes
WHERE total_time = (SELECT MIN(total_time) FROM recipes)


--  Stored procedure to check whether the provided rating score is valid (between 1 and 5) and then either updates an existing rating or inserts a new one
DROP PROCEDURE IF EXISTS sp_add_or_update_rating
GO

CREATE PROCEDURE sp_add_or_update_rating
    @UserID INT,
    @RecipeID INT,
    @RatingScore INT
AS
BEGIN
    -- Check if the rating score is valid (between 1 and 5)
    IF @RatingScore BETWEEN 1 AND 5
    BEGIN
        -- Check if the user has already rated the recipe
        IF EXISTS (
            SELECT 1
            FROM ratings
            WHERE rating_user_id = @UserID
            AND rating_recipe_id = @RecipeID
        )
        BEGIN
            -- Update the existing rating
            UPDATE ratings
            SET rating_score = @RatingScore
            WHERE rating_user_id = @UserID
            AND rating_recipe_id = @RecipeID

            PRINT 'Rating updated successfully.'
        END
        ELSE
        BEGIN
            -- Insert a new rating into the ratings table
            INSERT INTO ratings (rating_score, rating_user_id, rating_recipe_id)
            VALUES (@RatingScore, @UserID, @RecipeID)

            PRINT 'Rating inserted successfully.'
        END
    END
    ELSE
    BEGIN
        -- Print a message for an invalid rating score
        PRINT 'Invalid rating score. Please provide a score between 1 and 5.'
    END
END
GO

-- Valid rating
EXEC sp_add_or_update_rating @UserID = 2, @RecipeID = 1, @RatingScore = 4

SELECT * FROM ratings WHERE rating_user_id = 2 AND rating_recipe_id = 1

-- Invalid rating
EXEC sp_add_or_update_rating @UserID = 2, @RecipeID = 1, @RatingScore = 6

SELECT * FROM ratings WHERE rating_user_id = 2 AND rating_recipe_id = 1


-- Trigger to ensure that only valid difficulty levels (easy, medium, difficult) are inserted or updated in the recipes table
DROP TRIGGER IF EXISTS tr_enforce_difficulty_level
GO

CREATE TRIGGER tr_enforce_difficulty_level
ON recipes
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE difficulty_level NOT IN ('Easy', 'Medium', 'Difficult')
    )
    BEGIN
        ;
        THROW 50000, 'Invalid difficulty level. It must be easy, medium, or difficult.', 1
    END
END
GO
 
-- Valid difficulty level
UPDATE recipes
SET difficulty_level = 'Easy'
WHERE recipe_id = 1

SELECT * FROM recipes WHERE recipe_id = 1

-- Invalid difficulty level
UPDATE recipes
SET difficulty_level = 'Hard'
WHERE recipe_id = 1

SELECT * FROM recipes WHERE recipe_id = 1