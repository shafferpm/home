import random
import time


def double_first_amount(amounts):
    return amounts[0] * 2

def sum_odd_amounts(amounts):
    sum = 0
    for a in amounts:
        if a % 2:
            sum += a
    return sum

randomAmounts = [random.randint(1, 100) for _ in range(1000)]

start_time = time.time()
double_first_amount(randomAmounts)
double_duration = time.time() - start_time

start_time = time.time()
sum_odd_amounts(randomAmounts)
sum_duration = time.time() - start_time

print(f'Duration double: {double_duration}')
print(f'Duration sum: {sum_duration}')
print(f'Ratio of durations: {sum_duration/double_duration:.2f}')

