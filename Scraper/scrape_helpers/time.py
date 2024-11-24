def extract_time(recipe_soup, minutes_class, hours_class):
    """
    Extracts time (in minutes) from the given recipe_soup based on the provided class names for minutes and hours.

    Args:
        recipe_soup (BeautifulSoup): The BeautifulSoup object containing the recipe HTML.
        minutes_class (str): The class name for the element containing the minutes value.
        hours_class (str): The class name for the element containing the hours value.

    Returns:
        int: The total time in minutes. Returns 0 if no time elements are found.
    """
    total_time = 0

    mins_elem = recipe_soup.find(class_=minutes_class)
    if mins_elem:
        minutes = mins_elem.find(string=True, recursive=False)
        if minutes:
            total_time += int(minutes)

    hrs_elem = recipe_soup.find(class_=hours_class)
    if hrs_elem:
        hours = hrs_elem.find(string=True, recursive=False)
        if hours:
            total_time += int(hours) * 60

    return total_time