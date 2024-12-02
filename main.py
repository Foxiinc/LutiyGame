import asyncio
import logging
from aiogram import Router, Bot, Dispatcher, F
from aiogram.types import Message, WebAppInfo, InlineKeyboardButton, InlineKeyboardMarkup
from aiogram.filters import CommandStart
from aiogram.enums import ParseMode
from aiogram.utils.keyboard import InlineKeyboardBuilder
from aiogram.client.bot import DefaultBotProperties
BOT_TOKEN = "7232064667:AAG7ZWhu0CBGnsIXCVvh8Gvwxw-8YmIU4B8"


def webapp_builder() -> InlineKeyboardBuilder:
    builder = InlineKeyboardBuilder()
    builder.button(text='Играть!', web_app=WebAppInfo(
        url="https://sun6dt-37-193-200-13.ru.tuna.am",
    ))
    return builder.as_markup()

router = Router()

@router.message(CommandStart())
async def start(message: Message) -> None:
    await message.answer('Здарова!',
                        reply_markup=webapp_builder())
    
async def main():
    bot = Bot(BOT_TOKEN, default=DefaultBotProperties(parse_mode=ParseMode.HTML))
    dp = Dispatcher()
    dp.include_router(router)

    await bot.delete_webhook(drop_pending_updates=True)
    await dp.start_polling(bot)




if __name__ == "__main__":
    logging.basicConfig(level=logging.INFO)
    asyncio.run(main())
    
    loop = asyncio.get_event_loop()
    loop.run_until_complete(main(loop))
