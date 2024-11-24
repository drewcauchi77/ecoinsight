import json

def extract_ingredients(recipe_soup):
    """
    Extracts ingredient groups and their respective ingredients from the provided BeautifulSoup object.

    The function looks for all ingredient groups, retrieves the group titles, and parses
    each ingredient's details (amount, unit, name, notes). The extracted data is formatted
    into a JSON structure.
    
    Returns:
        str: A JSON string representing the ingredient groups and their ingredients.
             Returns an empty string if no ingredients are found.
    """
    ingredient_elems = recipe_soup.find_all(class_='wprm-recipe-ingredient-group')
    ingredient_groups = []

    if ingredient_elems:
        for elem in ingredient_elems:
            ingredient_group_title = elem.find(class_='wprm-recipe-group-name')
            ing_title = 'Ingredients'

            if ingredient_group_title:
                ing_title = ingredient_group_title.get_text(strip=True)

            ingredients_list = []
            ingredient_group = elem.find(class_='wprm-recipe-ingredients')

            if ingredient_group:
                ingredients = ingredient_group.find_all(class_='wprm-recipe-ingredient')
                if ingredients:
                    for ingredient in ingredients:
                        amount = ingredient.find(class_='wprm-recipe-ingredient-amount')
                        unit = ingredient.find(class_='wprm-recipe-ingredient-unit')
                        name = ingredient.find(class_='wprm-recipe-ingredient-name')
                        notes = ingredient.find(class_='wprm-recipe-ingredient-notes')

                        amount_text = amount.get_text(strip=True) if amount else ""
                        unit_text = unit.get_text(strip=True) if unit else ""
                        name_text = name.get_text(strip=True) if name else ""
                        notes_text = notes.get_text(strip=True) if notes else ""

                        ingredient_text = f"{amount_text} {unit_text} {name_text} {notes_text}".strip().replace('*', '')
                        ingredients_list.append(ingredient_text)

            ingredient_groups.append({
                'title': ing_title,
                'ingredients': ingredients_list
            })

    ingredients_json = json.dumps(ingredient_groups)
    return ingredients_json if ingredients_json != '[]' else ''