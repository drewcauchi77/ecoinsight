from bs4 import BeautifulSoup
from urllib.request import Request, urlopen

from scrape_helpers.title import extract_title
from scrape_helpers.description import extract_description
from scrape_helpers.source_anchor import extract_source_anchor
from scrape_helpers.serving_size import extract_serving_size
from scrape_helpers.time import extract_time
from scrape_helpers.ingredients import extract_ingredients

def is_valid_recipe_data(recipe_data):
    required_fields = ['Title', 'Description', 'SourceUrl', 'ServingSize', 'CookTime', 'PreparationTime', 'Ingredients']

    for field in required_fields:
        if not recipe_data.get(field):
            print(f"Missing or empty field: {field}")
            return False
    return True

scraped_titles = set()

def scrape_url(url, siteId):
    global scraped_titles
    print('Checking link: ' + url)

    recipe_req = Request(url, headers={'User-Agent': 'Mozilla/5.0'})
    recipe_res = urlopen(recipe_req).read()
    recipe_soup = BeautifulSoup(recipe_res, 'html.parser')
    
    page_type = recipe_soup.find('meta', attrs={'property': 'og:type'})['content']
    # breadcrumbs = recipe_soup.find(id='breadcrumbs')

    if page_type and page_type == 'recipe':
    # if breadcrumbs and 'Recipes' in breadcrumbs.get_text():
        print('Scraping link')

        # Title
        title = extract_title(recipe_soup)
        print('Title: ' + title) 

        if (title, siteId) in scraped_titles:
            print(f'Duplicate entry found: {title} (siteId: {siteId})')
        else:
            # Description
            description = extract_description(recipe_soup)
            print('Description: ', description)
            
            # SourceUrl
            source_url = url
            print('SourceUrl: ' + source_url)

            # SourceAnchor
            source_anchor = extract_source_anchor(recipe_soup)
            print('SourceAnchor: ', source_anchor)

            # ServingSize
            serving_size = extract_serving_size(recipe_soup)
            print('ServingSize: ', serving_size)

            # CookTime
            cook_time = extract_time(recipe_soup, 'wprm-recipe-cook_time-minutes', 'wprm-recipe-cook_time-hours')
            print('CookTime: ', cook_time)

            # PrepationTime
            prep_time = extract_time(recipe_soup, 'wprm-recipe-prep_time-minutes', 'wprm-recipe-prep_time-hours')
            print('PreparationTime: ', prep_time)

            # RecipeNutritions - TODO
            # nutrition_elems

            # Ingredients
            ingredients_json = extract_ingredients(recipe_soup)
            print('Ingredients: ', ingredients_json)

            recipe_data = {
                'Title': title,
                'Description': description,
                'SourceUrl': source_url,
                'SourceAnchor': source_anchor,
                'ServingSize': serving_size,
                'CookTime': cook_time,
                'PreparationTime': prep_time,
                'Ingredients': ingredients_json,
                'SiteId': siteId
            }

            if is_valid_recipe_data(recipe_data):
                scraped_titles.add((title, siteId))
                return recipe_data
            else:
                return False
    else:
        return False