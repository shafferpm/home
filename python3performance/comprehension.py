import random


def loop(orders):
    result = []
    for amount in orders:
        if amount > 50:
            result.append(2 * amount)
    return result

def comprehension(orders):
    return [2 * amount for amount in orders if amount > 50]

@profile
def main():
    orders = [random.randint(0, 100) for _ in range(100_000)]
    loop(orders)
    comprehension(orders)

main()