from collections import deque


@profile
def main():
    SIZE = 100_000

    big_list = list(range(SIZE))
    big_queue = deque(big_list)

    while big_list:
        big_list.pop()
    while big_queue:
        big_queue.pop()
    
    big_list = list(range(SIZE))
    big_queue = deque(big_list)

    while big_list:
        big_list.pop(0)
    while big_queue:
        big_queue.popleft()

main()

# First, in the terminal, run 
# kernprof -lv deque.py

