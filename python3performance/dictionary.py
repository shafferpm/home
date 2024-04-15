import random

def search_list(big_list, items):
    count = 0
    for item in items:
        for order in big_list:
            if item == order[0]:
                count += 1
    return count

def search_dictionary(some_dictionary, items):
    count = 0
    for item in items:
        if item in some_dictionary:
            count += 1
    return count

@profile
def main():
    SIZE = 100_000

    big_list = []
    big_dictionary = {}

    for i in range(SIZE):
        big_list.append([i, 2 * i, i * i])
        big_dictionary[i] = [2 * i, i * i]

    orders_to_search = [random.randint(0, SIZE) for _ in range(1000)]
    search_list(big_list, orders_to_search)
    search_dictionary(big_dictionary, orders_to_search)

main()

# First, in the terminal, run
# python -m timeit '{"order_id":1}'
# returned "5000000 loops, best of 5: 39.5 nsec per loop" in the output of the terminal

# Second, in the terminal run
# python -m timeit -s 'from collections import namedtuple; Order=namedtuple("Order", "order_id")' 'Order(1)'
# returned "1000000 loops, best of 5: 246 nsec per loop" in the output of the terminal

# Third, in the terminal run
# python -m timeit -s """
# from dataclasses import dataclass
# @dataclass
# class Order:
#     order_id: int
# """ 'Order(1)'
# returned "2000000 loops, best of 5: 135 nsec per loop" in the output of the terminal

# Next, to measure the time it takes to access order ids.
# First in the terminal, run for the dictionary
# python -m timeit -s 'order={"order_id":1}' 'order["order_id"]'
# returned "10000000 loops, best of 5: 18.6 nsec per loop" in the output of the terminal

# Second, in the terminal, run for the namedtuple
# python -m timeit -s 'from collections import namedtuple; Order=namedtuple("Order", "order_id")' 'order=Order(1)' 'order.order_id'
# returned "1000000 loops, best of 5: 248 nsec per loop" in the output of the terminal

# Third, in the terminal, run for the dataclass
# python -m timeit -s """
# from dataclasses import dataclass
# @dataclass
# class Order:
#     order_id: int
# 'order=Order(1)""" 'order.order_id'
# returned "2000000 loops, best of 5: 135 nsec per loop" in the output of the terminal
# 20000000 loops, best of 5: 13.6 nsec per loop

