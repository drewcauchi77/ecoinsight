def extract_description(recipe_soup):
    """
    Extracts the description of a recipe from the provided BeautifulSoup object.

    The function attempts to find the recipe description by checking for specific elements
    in the following order of priority:
    1. Looks for an element with the class 'wprm-recipe-summary'.
    2. If not found, checks the meta tag with the attribute 'name=description'.
    3. If still not found, checks the meta tag with the attribute 'property=og:description'.

    Returns:
        str: The extracted description if found; otherwise, an empty string.
    """
    description = ''
    description_elem = recipe_soup.find(class_='wprm-recipe-summary')

    if description_elem:
        description = description_elem.get_text(strip=True)
    else:
        meta_description_elem = recipe_soup.find('meta', attrs={'name': 'description'})

        if meta_description_elem and 'content' in meta_description_elem.attrs:
            description = meta_description_elem['content']
        else:
            og_description_elem = recipe_soup.find('meta', attrs={'property': 'og:description'})

            if og_description_elem and 'content' in og_description_elem.attrs:
                description = og_description_elem['content']

    return description