<?php
/**
 * @var \App\View\AppView $this
 * @var \App\Model\Entity\Shootingleveldesign $shootingleveldesign
 */
?>
<nav class="large-3 medium-4 columns" id="actions-sidebar">
    <ul class="side-nav">
        <li class="heading"><?= __('Actions') ?></li>
        <li><?= $this->Form->postLink(
                __('Delete'),
                ['action' => 'delete', $shootingleveldesign->Number],
                ['confirm' => __('Are you sure you want to delete # {0}?', $shootingleveldesign->Number)]
            )
        ?></li>
        <li><?= $this->Html->link(__('List Shootingleveldesign'), ['action' => 'index']) ?></li>
    </ul>
</nav>
<div class="shootingleveldesign form large-9 medium-8 columns content">
    <?= $this->Form->create($shootingleveldesign) ?>
    <fieldset>
        <legend><?= __('Edit Shootingleveldesign') ?></legend>
        <?php
            echo $this->Form->control('Level');
            echo $this->Form->control('Pattern');
            echo $this->Form->control('PosX');
            echo $this->Form->control('PosY');
            echo $this->Form->control('PosZ');
            echo $this->Form->control('RateX');
            echo $this->Form->control('RateY');
            echo $this->Form->control('RateZ');
            echo $this->Form->control('ScaleX');
            echo $this->Form->control('ScaleY');
            echo $this->Form->control('ScaleZ');
        ?>
    </fieldset>
    <?= $this->Form->button(__('Submit')) ?>
    <?= $this->Form->end() ?>
</div>
