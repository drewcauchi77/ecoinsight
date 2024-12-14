import requests

from api_helpers import get_urls_from_sitemap, post_recipe_to_api
from scrape_helpers import scrape_url

url = "http://localhost:5149/api/sitemap"

try:
    response = requests.get(url, verify=False)
    response.raise_for_status()
    data = response.json()

    for item in data:

        if item['url'] != '' and item['shouldScrape']:
            recipe_list = get_urls_from_sitemap(item['url'])

            for recipe in recipe_list:
                scraped_data = scrape_url(recipe, item['siteId'])

                if scraped_data != False:
                    post_recipe_to_api(scraped_data)
except requests.exceptions.RequestException as e:
    print(f"An error occurred: {e}")
