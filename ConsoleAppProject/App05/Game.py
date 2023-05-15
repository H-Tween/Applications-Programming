import pygame
import random

pygame.init()

HEIGHT = 600
WIDTH = 1000

screen = pygame.display.set_mode([WIDTH, HEIGHT])

pygame.display.set_caption('Game')
font = pygame.font.Font('freesansbold.ttf', 20)
largeFont = pygame.font.Font('freesansbold.ttf', 40)

fps = 60
timer = pygame.time.Clock()

newMap = True
mapRectangles = []
rectangleWidth = 5
rectangleTotal = WIDTH//rectangleWidth
padding = 15

playerX = 100
playerY = 300

flying = False
playerSpeedY = 0
gravity = 0.3
mapSpeed = 2

score = 0
highScore = 0
active = True
countdown = 0
restart = False
startTimer = 0#
endGameCounter = 0

flickering = False

playerImage = pygame.transform.scale(pygame.image.load('ConsoleAppProject\App05\heliPic.png'), (70, 40))


def generateNew():
    global playerY
    rectangles =[]
    topHeight = random.randint(0,300)
    playerY = topHeight + 150

    for i in range(rectangleTotal):
        topHeight = random.randint(topHeight - padding, topHeight + padding)
        if topHeight < 0:       # if padding takes the square off the screen
            topHeight = 0
        elif topHeight > 300:   # if padding takes the square off the screen
            topHeight = 300
        rectangleTop = pygame.draw.rect(screen, 'purple', [i * rectangleWidth, 0, rectangleWidth, topHeight])
        rectangleBottom = pygame.draw.rect(screen, 'purple', [i * rectangleWidth, topHeight + 300, rectangleWidth, HEIGHT])
        rectangles.append(rectangleTop)
        rectangles.append(rectangleBottom)
    return rectangles

def drawMap(rectangles):
    for i in range(len(rectangles)):
        pygame.draw.rect(screen, 'purple', rectangles[i])
    pygame.draw.rect(screen, 'dark gray', [0, 0, WIDTH, HEIGHT], 12)

def drawPlayer():
    # draw player hitbox and image
    #screen.blit(playerImage, (playerX - 45, playerY - 25))
    player = pygame.draw.circle(screen, 'black', (playerX, playerY), 20)
    screen.blit(playerImage, (playerX - 45, playerY - 25))
    return player

def movePlayer(playerY, speed, flying):
    if flying:
        speed += gravity
    else:
        speed -= gravity

    playerY -= speed

    return playerY, speed

def drawStartCounter(currentCountDown):
    if currentCountDown < 60:
        startTimer = 3
    elif currentCountDown < 120:
        startTimer = 2
    else:
        startTimer = 1

    startGameText = largeFont.render(f'Starting in: {startTimer}', True, 'white')
    screen.blit(startGameText, (330, 300))

def drawEndGame():
    endGameText = largeFont.render(f'GAME OVER', True, 'white')
    screen.blit(endGameText, (330, 300))


    

def moveRectangles(rectangles):
    global score
    for i in range(len(rectangles)):
        rectangles[i] = (rectangles[i][0] - mapSpeed, rectangles[i][1], rectangleWidth, rectangles[i][3])
        if rectangles[i][0] + rectangleWidth < 0:
            rectangles.pop(1) # top rectangle    ( both have same X coordinate)
            rectangles.pop(0) # bottom rectangle
            topHeight = random.randint(rectangles[-2][3] - padding, rectangles[-2][3] + padding)

            if topHeight < 0:       # if padding takes the square off the screen
                topHeight = 0
            elif topHeight > 300:   # if padding takes the square off the screen
                topHeight = 300
            rectangles.append((rectangles[-2][0] + rectangleWidth, 0, rectangleWidth, topHeight))
            rectangles.append((rectangles[-2][0] + rectangleWidth, topHeight + 300, rectangleWidth, HEIGHT))
            score += 1

    return rectangles

def collisionCheck(rectangles, playerCircle, active):
    for i in range(len(rectangles)):
        if playerCircle.colliderect(rectangles[i]):
            active = False

    return active

run = True

while run:
    screen.fill('black')
    timer.tick(fps)

    if not restart:
    # Countdown
        if countdown < 180:
            countdown += 1
            active = False
        else:
            active = True
    
    if endGameCounter < 180:
        endGameCounter += 1
    else:
        endGameCounter = 0

    if endGameCounter > 60 and endGameCounter < 120:
        flickering = True
    else:
        flickering = False





    if newMap:
        mapRectangles = generateNew()
        newMap = False

    drawMap(mapRectangles)
    player = drawPlayer()
    if active:
        playerY, playerSpeedY = movePlayer(playerY, playerSpeedY, flying)
        mapRectangles = moveRectangles(mapRectangles)
    if countdown == 180 and active:
        active = collisionCheck(mapRectangles, player, active)
        if active == False:
            restart = True

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            run = False
        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_SPACE:
                flying = True
            if event.key == pygame.K_RETURN:
                if not active and restart:
                    newMap = True
                    active = False
                    restart = False
                    countdown = 0
                    playerSpeedY = 0
                    mapSpeed = 2
                    if score > highScore:
                        highScore = score
                    score = 0

        if event.type == pygame.KEYUP:
            if event.key == pygame.K_SPACE:
                flying = False


    mapSpeed = 2 + (score//50)/4

    screen.blit(font.render(f'Score: {score}', True, 'white'), (20, 15))
    #screen.blit(font.render(f'High Score: {highScore}', True, 'white'), (850, 15))
    screen.blit(font.render(f'High Score: {highScore}', True, 'white'), (20, 565))
    if not active:
        screen.blit(font.render('Press Enter to Restart', True, 'white'), (380, 565))

    if countdown < 180:
        drawStartCounter(countdown)

    if not active and restart and not flickering:
        drawEndGame()


    pygame.display.flip()

pygame.quit()