import re

def extract_title(recipe_soup):
    """
    Extracts the title of a recipe from the provided BeautifulSoup object.

    The function performs the following steps:
    1. Looks for an element with the class 'wprm-recipe-name' inside a container with the class 'wprm-recipe-container'.
    2. Retrieves the text content of the found element, if it exists.
    3. Removes any text within parentheses (and the parentheses themselves) from the title.
    4. Strips any leading or trailing whitespace.

    Returns:
        str: The cleaned recipe title if found; otherwise, an empty string.
    """
    title = ''
    container = recipe_soup.find(class_='wprm-recipe-container')

    if container:
        title_elem = container.find(class_='wprm-recipe-name')
        if title_elem:
            title = title_elem.get_text().strip()
            title = re.sub(r'\(.*?\)', '', title).strip()

    return title