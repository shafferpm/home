import asyncio
import time

async def process_order():
    #await asyncio.sleep(1)
    #time.sleep(3)
    for _ in range(100_000_000):
        pass
    print('Order complete')

async def main():
    #await process_order()
    await asyncio.gather(process_order(), process_order())
    print('Finished processing')

asyncio.run(main())

# time python challenges_asyncio.py

# Note: Asyncio does not really improve performance of CPU intensive tasks. It is more useful for I/O bound tasks.

