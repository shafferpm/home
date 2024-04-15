import random

def get_random_integer():
    return random.randint(0, 100)


@profile
def main():
    # This is the fastest way, but is not object oriented.
    [random.randint(0, 100) for _ in range(100_000)]

    # This is the second fastest way, but is not object oriented.
    [get_random_integer() for _ in range(100_000)]

    # This is the slowest way.
    [(lambda: random.randint(0, 100))() for _ in range(100_000)]
  
main()

# First, to profile the functions.py file, use the following command:
# kernprof -lv functions.py

