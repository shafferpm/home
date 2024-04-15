from functools import lru_cache
import random

# from line_profiler import profile

@lru_cache
def get_order_details(order_id):
    for i in range(100_000):
        pass
    return 100 * order_id

@profile
def main():
    orders_to_search = [random.randint(0, 100) for _ in range(1000)]
    for order in orders_to_search:
        get_order_details(order)

main()
