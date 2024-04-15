import random


def search(items, collection):
    count = 0
    for i in items:
        if i in collection:
            count += 1
    return count

@profile
def main():
    SIZE = 1_000_000

    big_list = list(range(SIZE))
    big_set = set(big_list)
    big_tuple = tuple(big_list)

    items_to_find = [random.randint(0, SIZE) for _ in range(1000)]

    search(items_to_find, big_list)
    search(items_to_find, big_set)
    search(items_to_find, big_tuple)

main()

# First, in the terminal, run 
# python -m memory_profiler set_tuple.py

# Second, to see the performance, run
# kernprof -lv set_tuple.py