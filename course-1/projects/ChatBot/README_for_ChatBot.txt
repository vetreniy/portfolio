Это небольшой (так как я не знаю, что тут рассказать, чатбот как чатбот) README о проекте, продуктом которого является Чат-бот.

Он имеет команды:
	/start - начало работы
	/help - помощь (вывод списка команд)
	/clear - очистка диалога
	/undo - отмена последнего сообщения пользователя и ответа на него от Чат-бота
	/summarize - краткий пересказ диалога
	/stats - статистика диалога

UID бота: @xaku_chat_bot

для запуска нужны команды:
	lt --port 5000 --subdomain altratelegrambot
	curl -X POST "https://api.telegram.org/bot8675865234:AAGdXNcSUrD4XXFvuh82vWIEx6dlNDL0Ngo/setWebhook?url=https://altratelegrambot.loca.lt/api/update"
	API-ключ, Модель Нейросети и Токен Бота можно найти в appsettings.json

