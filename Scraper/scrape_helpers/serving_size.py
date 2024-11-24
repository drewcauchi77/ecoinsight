def extract_serving_size(recipe_soup):
    """
    Extracts the serving size for a recipe from the provided BeautifulSoup object.

    The function identifies the serving size by:
    1. Locating an element with the class 'wprm-recipe-servings-label'.
    2. Finding its next sibling element, which contains the actual serving size value.
    3. Extracting and returning the concatenated text content of the sibling element's children, ensuring proper spacing.

    Returns:
        str: The extracted serving size as a string if found; otherwise, an empty string.
    """
    servings_label_elem = recipe_soup.find(class_='wprm-recipe-servings-label')
    serving_size = ''
    if servings_label_elem:
        serving_size_elem = servings_label_elem.find_next_sibling()

        if serving_size_elem:
            serving_size_parts = [
                child.get_text(strip=True) for child in serving_size_elem.children if child.get_text(strip=True)
            ]
            serving_size = ' '.join(serving_size_parts)

    return serving_size