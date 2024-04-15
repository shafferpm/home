import random


@profile
def main():
    orders = [random.randint(0, 100) for _ in range(100_000)]

    comprehension = [2 * amount for amount in orders if amount > 50]
    generator = (2 * amount for amount in orders if amount > 50)

    sum(comprehension)
    sum(generator)

main()

# To view the memory consumption, use the memory_profiler tool with the following command:
# python -m memory_profiler generator.py

