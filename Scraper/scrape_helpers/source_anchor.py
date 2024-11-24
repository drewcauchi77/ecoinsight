def extract_source_anchor(recipe_soup):
    """
    Extracts the source anchor (link) for the recipe from the provided BeautifulSoup object.

    The function attempts to locate the source anchor in the following order of priority:
    1. Checks for an element with the class 'wprm-recipe-jump' and retrieves its 'href' attribute.
    2. If not found, falls back to finding the recipe container with the class 'wprm-recipe-container',
       and constructs an anchor link using its 'id' attribute (prefixed with '#').

    Returns:
        str: The extracted source anchor link if found; otherwise, an empty string.
    """ 
    source_anchor_elem = recipe_soup.find(class_='wprm-recipe-jump')
    source_anchor = ''
    if source_anchor_elem:
        source_anchor = source_anchor_elem.get('href')
    else:
        recipe_container = recipe_soup.find('div', class_='wprm-recipe-container')

        if recipe_container:
            source_anchor = '#' + recipe_container.get('id')

    return source_anchor