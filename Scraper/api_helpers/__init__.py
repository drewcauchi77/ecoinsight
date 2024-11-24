import requests
import json
from bs4 import BeautifulSoup
from urllib.request import Request, urlopen

def get_urls_from_sitemap(url):
    sitemap_req = Request(url, headers={'User-Agent': 'Mozilla/5.0'})
    sitemap_res = urlopen(sitemap_req).read()
    sitemap_soup = BeautifulSoup(sitemap_res, features="xml")
    recipe_urls = sitemap_soup.select('url > loc')

    recipes = [recipe.text for recipe in recipe_urls]
    return recipes

def post_recipe_to_api(recipe_data):
    url = "http://localhost:5149/api/recipe"
    headers = {'Content-Type': 'application/json'}

    try:
        response = requests.post(url, headers=headers, data=json.dumps(recipe_data))
        response.raise_for_status()
        print("Recipe created:", response.json())
    except requests.exceptions.RequestException as e:
        print(f"Failed to create recipe: {e}")