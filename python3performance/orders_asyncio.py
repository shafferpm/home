import asyncio

async def process_order():
    await asyncio.sleep(1)
    print('Order complete')

async def main():
    await process_order()
    await process_order()
    print('Finished processing')

asyncio.run(main())
