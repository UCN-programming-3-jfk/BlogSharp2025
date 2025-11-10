-- Insert a cooking blog author
INSERT INTO Author (Email, PasswordHash, BlogTitle) 
VALUES ('chef.maria@cookingblog.com', '$2a$12$LQv3c1yqBwLVzjzVfOaFeOGXmO/b.6n2z2d5F2M5x5o8m6s3l1qEm', 'Maria''s Kitchen Adventures');

-- Declare variable to store the author ID for use in blog posts
DECLARE @AuthorId INT = SCOPE_IDENTITY();

-- Insert five cooking/recipe blog posts
INSERT INTO BlogPost (Title, TextBody, CreationDate, FK_Author_Id) VALUES 
('Perfect Homemade Pizza Dough Recipe', 
'Creating the perfect pizza dough from scratch is easier than you think! This recipe yields a beautifully elastic dough with amazing flavor. Start with 3 cups of bread flour, 1 tsp salt, 1 tbsp sugar, and 1 packet of active dry yeast. Mix warm water (110°F) with the yeast and sugar, let it foam for 5 minutes. Combine dry ingredients, add the yeast mixture and olive oil. Knead for 8-10 minutes until smooth and elastic. Let rise for 1-2 hours until doubled in size. This dough can be used immediately or stored in the refrigerator for up to 3 days for even better flavor development.',
'2024-11-01 14:30:00',
@AuthorId),

('Classic Chicken Parmesan - Restaurant Quality', 
'This restaurant-style Chicken Parmesan will become your go-to comfort food recipe. Pound chicken breasts to even thickness, season with salt and pepper. Set up a breading station: flour, beaten eggs with a splash of milk, and seasoned breadcrumbs mixed with parmesan cheese. Coat each piece thoroughly and pan-fry in olive oil until golden brown. Top with marinara sauce and mozzarella cheese, then bake at 425°F for 15-20 minutes until cheese is bubbly and golden. Serve over pasta with fresh basil and extra parmesan. The key is not overcooking the chicken - it should be juicy and tender inside with a crispy coating.',
'2024-11-03 16:45:00',
@AuthorId),

('Decadent Chocolate Lava Cake in 15 Minutes', 
'Impress your guests with this foolproof chocolate lava cake that takes only 15 minutes from start to finish! Melt 4 oz dark chocolate with 4 tbsp butter in the microwave. Whisk in 2 eggs, 2 tbsp sugar, pinch of salt, and 2 tbsp flour until just combined - don''t overmix! Butter and dust ramekins with cocoa powder, divide batter evenly. Bake at 425°F for exactly 12-14 minutes. The edges should be firm but center slightly jiggly. Let cool for 1 minute, then run a knife around edges and invert onto plates. Dust with powdered sugar and serve immediately with vanilla ice cream. The molten center is pure magic!',
'2024-11-05 19:20:00',
@AuthorId),

('Fresh Herb Garden Pasta Salad for Summer', 
'This vibrant pasta salad celebrates the best of summer herbs and vegetables. Cook 1 lb penne pasta al dente, drain and rinse with cold water. Combine with halved cherry tomatoes, diced cucumber, red onion, and crumbled feta cheese. For the dressing, whisk together olive oil, lemon juice, minced garlic, and fresh herbs - basil, oregano, and parsley work beautifully together. Season with salt and pepper, toss everything together and chill for at least 2 hours. The flavors develop and meld together perfectly. Add fresh herbs just before serving for the brightest flavor. Perfect for potlucks, picnics, or light summer dinners.',
'2024-11-07 11:15:00',
@AuthorId),

('Asian-Style Beef and Broccoli Stir Fry', 
'Skip the takeout and make this healthier, more flavorful beef and broccoli at home! Slice 1 lb flank steak against the grain into thin strips. Marinate in soy sauce, cornstarch, and a touch of oil for 15 minutes. Heat wok or large skillet over high heat, cook beef in batches until just done - don''t overcrowd! Remove beef, add broccoli florets with a splash of water, cover and steam for 2 minutes. Return beef to pan with sauce made from soy sauce, oyster sauce, garlic, ginger, and a cornstarch slurry. Everything comes together in under 20 minutes. Serve over steamed rice with sesame seeds and green onions.',
'2024-11-09 13:00:00',
@AuthorId);