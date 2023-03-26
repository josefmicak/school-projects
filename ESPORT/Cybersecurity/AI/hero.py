import pygame
from my_object import My_Object


class Hero(My_Object):
    def __init__(self, screen_width, screen_height, left_offset, right_offset, down_offset, direction, action, image_id, health, type, x=None, y=None):
        super().__init__(screen_width, screen_height, left_offset, right_offset, down_offset, direction, action, image_id, health, type, x, y)
        self.x = x
        self.y = y
        self.left_offset = left_offset
        self.right_offset = right_offset
        self.down_offset = down_offset
        self.action = action
        self.image_id = image_id
        self.health = health
        self.img = pygame.image.load('hero/Idle/0_Warrior_Idle Blinking_000.png')

    def show(self, game_display):
        game_display.blit(self.img, (self.x, self.y))

    def get_height(self):
        return self.img.get_height()

    def get_width(self):
        return self.img.get_width()

    def update_image(self, image_id):
        if self.action == 'Idle':
            if image_id < 10:
                path = 'hero/Idle/0_Warrior_Idle Blinking_00' + str(image_id) + '.png'
            else:
                path = 'hero/Idle/0_Warrior_Idle Blinking_0' + str(image_id) + '.png'
        elif self.action == 'Walking':
            if image_id < 10:
                path = 'hero/Walking/0_Warrior_Run_00' + str(image_id) + '.png'
            else:
                path = 'hero/Walking/0_Warrior_Run_0' + str(image_id) + '.png'
        elif self.action == 'Attacking':
            if image_id < 10:
                path = 'hero/Attacking/0_Warrior_Attack_2_00' + str(image_id) + '.png'
            else:
                path = 'hero/Attacking/0_Warrior_Attack_2_0' + str(image_id) + '.png'
        elif self.action == 'Hurt':
            if image_id < 10:
                path = 'hero/Hurt/0_Warrior_Hurt_00' + str(image_id) + '.png'
            else:
                path = 'hero/Hurt/0_Warrior_Hurt_0' + str(image_id) + '.png'
        elif self.action == 'Dying':
            if image_id < 10:
                path = 'hero/Dying/0_Warrior_Died_00' + str(image_id) + '.png'
            else:
                path = 'hero/Dying/0_Warrior_Died_0' + str(image_id) + '.png'
        self.img = pygame.image.load(path)