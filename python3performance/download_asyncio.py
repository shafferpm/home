import asyncio
import aiohttp
from urllib import request


def download():
    return request.urlopen('https://google.com').read()

def synchronous():
    for _ in range(5):
        download()

async def async_download(session, url):
    async with session.get(url) as response:
        return await response.text()

async def asynchronous():
    async with aiohttp.ClientSession() as session:
        coroutines = [async_download(session, 'https://google.com') for _ in range(5)]
        await asyncio.gather(*coroutines)


@profile
def main():
    synchronous()
    asyncio.run(asynchronous())

main()

# pip install aiohttp
# kernprof -lv download_asyncio.py

