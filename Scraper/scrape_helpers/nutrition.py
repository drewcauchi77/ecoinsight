from decimal import Decimal

def extract_nutrition(recipe_soup):
    nutrition_elems = recipe_soup.find_all(class_='wprm-nutrition-label-text-nutrition-container')
    if nutrition_elems:
        for elem in nutrition_elems:
            nutrition_name_elem = elem.find(class_='wprm-nutrition-label-text-nutrition-label')
            nutrition_name = ''
            if nutrition_name_elem:
                nutrition_name = nutrition_name_elem.get_text().strip().replace(':', '')
            
            nutrition_amount_elem = elem.find(class_='wprm-nutrition-label-text-nutrition-value')
            nutrition_amount = Decimal(0)
            if nutrition_amount_elem:
                nutrition_amount = Decimal(nutrition_amount_elem.get_text().strip())

            nutrition_unit_elem = elem.find(class_='wprm-nutrition-label-text-nutrition-unit')
            nutrition_unit = ''
            if nutrition_unit_elem:
                nutrition_unit = nutrition_unit_elem.get_text().strip()
            
    print(nutrition_name + ': ' + str(nutrition_amount) + nutrition_unit)